namespace CybersecurityChatbot;

/// <summary>
/// Drives the main conversation loop between the user and the bot.
/// </summary>
internal class ChatBot
{
    public UserSession Session { get; }
    public int MessageCount { get; private set; }

    public ChatBot(UserSession session)
    {
        Session = session;
    }

    public void Run()
    {
        DisplayHelper.SectionHeader($"Chat started — {Session.StartTime:HH:mm}");
        DisplayHelper.BotSay($"What would you like to know about cybersecurity today, {Session.Name}?");

        bool running = true;

        while (running)
        {
            string? input = DisplayHelper.PromptUser(Session.Name);

            if (input is null) { running = false; continue; }

            string trimmed = input.Trim();

            if (string.IsNullOrWhiteSpace(trimmed))
            {
                DisplayHelper.Warn("Your message was empty. Please type a question or 'help' to see topics.");
                continue;
            }

            string? response = ResponseEngine.GetResponse(trimmed, Session.Name);
            MessageCount++;

            if (response is null)
                running = false;
            else
            {
                Console.WriteLine();
                PrintFormattedResponse(response);
                Console.WriteLine();
            }
        }

        ShowFarewell();
    }

    private static void PrintFormattedResponse(string response)
    {
        foreach (string line in response.Split('\n'))
        {
            if (line.TrimStart().StartsWith("•"))
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(line);
                Console.ResetColor();
            }
            else
            {
                DisplayHelper.BotSay(line, typed: true);
            }
        }
    }

    private void ShowFarewell()
    {
        Console.WriteLine();
        DisplayHelper.PrintDivider('═', DisplayHelper.AccentColour);
        DisplayHelper.BotSay($"Goodbye, {Session.Name}! Stay safe online. ", typed: false);
        DisplayHelper.BotSay($"You asked {MessageCount} question(s) in this session.", typed: false);
        DisplayHelper.PrintDivider('═', DisplayHelper.AccentColour);
        Console.WriteLine();
    }
}