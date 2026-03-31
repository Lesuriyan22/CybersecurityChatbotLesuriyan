namespace CybersecurityChatbot;

/// <summary>
/// Represents the current user's session data.
/// Uses automatic properties as required by the assignment brief.
/// </summary>
internal class UserSession
{
    // ── Auto-properties ───────────────────────────────────────────────────────
    public string Name { get; set; } = "User";
    public DateTime StartTime { get; init; } = DateTime.Now;

    /// <summary>
    /// Prompts for the user's name, validates input, and returns a populated session.
    /// </summary>
    public static UserSession InitialiseSession()
    {
        DisplayHelper.SectionHeader("Welcome");
        DisplayHelper.BotSay("Hello! I'm your Cybersecurity Awareness Assistant.", typed: false);
        DisplayHelper.BotSay("Before we begin, may I ask for your name?");

        string? name = null;

        while (string.IsNullOrWhiteSpace(name))
        {
            name = DisplayHelper.PromptUser("Your name");

            if (string.IsNullOrWhiteSpace(name))
            {
                DisplayHelper.Warn("Name cannot be empty. Please enter your name.");
                name = null;
            }
        }

        name = name.Trim();
        var session = new UserSession { Name = name };

        Console.WriteLine();
        DisplayHelper.BotSay($"Great to meet you, {session.Name}! 🎉", typed: false);
        DisplayHelper.BotSay("I'm here to help you stay safe online. Type 'help' to see what I can do, or 'quit' to exit.");
        Console.WriteLine();

        return session;
    }
}
