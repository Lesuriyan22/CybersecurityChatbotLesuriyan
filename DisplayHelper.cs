namespace CybersecurityChatbot;

/// <summary>
/// Handles all console visual output: ASCII art, colours, borders, typing effect.
/// </summary>
internal static class DisplayHelper
{
    // ── Colour palette ────────────────────────────────────────────────────────
    public static readonly ConsoleColor AccentColour = ConsoleColor.Cyan;
    public static readonly ConsoleColor BotColour = ConsoleColor.Green;
    public static readonly ConsoleColor UserColour = ConsoleColor.Yellow;
    public static readonly ConsoleColor WarningColour = ConsoleColor.Red;
    public static readonly ConsoleColor DimColour = ConsoleColor.DarkGray;

    // ── ASCII logo ────────────────────────────────────────────────────────────
    private static readonly string[] Logo =
 {
    @"        ██████╗██╗   ██╗██████╗ ███████╗██████╗ ",
    @"       ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗",
    @"       ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝",
    @"       ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗",
    @"       ╚██████╗   ██║   ██████╔╝███████╗██║  ██║",
    @"        ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝",
    @"                                                  ",
    @"          \n┌─────────────────────────────────────────┐",
    @"          │            SHIELD ACTIVATED             │",
    @"          │   Cybersecurity Awareness Bot v1.0      │",
    @"          │        Protecting South Africa          │",
    @"          └─────────────────────────────────────────┘",
};

    // ── Public methods ────────────────────────────────────────────────────────

    /// <summary>Clears the console and renders the full launch banner.</summary>
    public static void ShowBanner()
    {
        Console.Clear();
        PrintDivider('═', AccentColour);

        foreach (string line in Logo)
        {
            Console.ForegroundColor = AccentColour;
            Console.WriteLine(line);
        }

        Console.ResetColor();
        PrintDivider('═', AccentColour);
        Console.WriteLine();
    }

    /// <summary>Writes a full-width divider using the supplied character and colour.</summary>
    public static void PrintDivider(char ch = '─', ConsoleColor colour = ConsoleColor.DarkCyan)
    {
        int width = Math.Min(Console.WindowWidth > 0 ? Console.WindowWidth - 1 : 70, 70);
        Console.ForegroundColor = colour;
        Console.WriteLine(new string(ch, width));
        Console.ResetColor();
    }

    /// <summary>Prints a bot message with a label, optional typing delay, and colour.</summary>
    public static void BotSay(string message, bool typed = true)
    {
        Console.ForegroundColor = BotColour;
        Console.Write("[Bot] ");
        Console.ResetColor();

        if (typed)
            TypeWrite(message, ConsoleColor.White);
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    /// <summary>Prompts the user and reads their input with yellow colouring.</summary>
    public static string? PromptUser(string label = "You")
    {
        Console.WriteLine();
        Console.ForegroundColor = UserColour;
        Console.Write($"[{label}] > ");
        Console.ResetColor();
        return Console.ReadLine();
    }

    /// <summary>Displays a section header with surrounding dividers.</summary>
    public static void SectionHeader(string title)
    {
        Console.WriteLine();
        PrintDivider('─', DimColour);
        Console.ForegroundColor = AccentColour;
        Console.WriteLine($"  📌  {title.ToUpper()}");
        Console.ResetColor();
        PrintDivider('─', DimColour);
    }

    /// <summary>Prints text character-by-character to simulate a typing feel.</summary>
    public static void TypeWrite(string text, ConsoleColor colour = ConsoleColor.White, int delayMs = 18)
    {
        Console.ForegroundColor = colour;
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delayMs);
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    /// <summary>Prints a warning / error line in red.</summary>
    public static void Warn(string message)
    {
        Console.ForegroundColor = WarningColour;
        Console.WriteLine($"  ⚠  {message}");
        Console.ResetColor();
    }
}