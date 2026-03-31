namespace CybersecurityChatbot;

/// <summary>
/// Matches user input to cybersecurity topic responses.
/// </summary>
internal static class ResponseEngine
{
    private static readonly (string[] Keywords, string Response)[] ResponseMap =
    {
        (new[]{ "hello", "hi", "hey", "greetings" },
            "Hello! I'm doing well and ready to help you stay cyber-safe. What would you like to know?"),

        (new[]{ "how are you", "how r u", "how do you do" },
            "I'm functioning perfectly and fully charged to tackle cyber threats! How can I assist you today?"),

        (new[]{ "\npurpose", "what do you do", "what can you do", "why are you here" },
            "My purpose is to educate South African citizens about cybersecurity threats and how to stay safe online. " +
            "I can help with topics like phishing, passwords, malware, safe browsing, and more!"),

        (new[]{ "what can i ask", "topics", "help", "menu", "options" },
            BuildHelpText()),

        (new[]{ "password", "passwords", "passphrase" },
            " PASSWORD SAFETY TIPS:\n" +
            "  • Use at least 12 characters mixing UPPER, lower, numbers & symbols.\n" +
            "  • Never reuse passwords across different sites.\n" +
            "  • Consider a reputable password manager (e.g. Bitwarden).\n" +
            "  • Enable Two-Factor Authentication (2FA) wherever possible.\n" +
            "  • Change passwords immediately if you suspect a breach."),

        (new[]{ "phishing", "phish", "fake email", "suspicious email" },
            " PHISHING AWARENESS:\n" +
            "  • Verify the sender's email address carefully — fraudsters spoof real brands.\n" +
            "  • Never click links in unsolicited emails; go directly to the website.\n" +
            "  • Look for poor grammar, urgent language, or unexpected attachments.\n" +
            "  • South African banks will NEVER ask for your PIN via email or SMS.\n" +
            "  • Report phishing to the SAPS Cybercrime Unit: www.saps.gov.za"),

        (new[]{ "browsing", "safe browsing", "browser", "website", "https", "http" },
            " SAFE BROWSING TIPS:\n" +
            "  • Always check for 'https://' and the padlock icon before entering data.\n" +
            "  • Avoid using public Wi-Fi for banking or sensitive tasks.\n" +
            "  • Keep your browser and extensions up to date.\n" +
            "  • Use a reputable ad-blocker to reduce malicious ad exposure.\n" +
            "  • Consider a VPN when using unfamiliar networks."),

        (new[]{ "malware", "virus", "ransomware", "spyware", "trojan" },
            " MALWARE PROTECTION:\n" +
            "  • Install reputable antivirus software and keep definitions updated.\n" +
            "  • Never download software from untrusted sources or piracy sites.\n" +
            "  • Be cautious of USB drives from unknown sources.\n" +
            "  • Back up important files regularly (offline or encrypted cloud).\n" +
            "  • If infected, disconnect from the internet immediately and seek help."),

        (new[]{ "social engineering", "manipulation", "pretexting", "vishing", "smishing" },
            " SOCIAL ENGINEERING:\n" +
            "  • Attackers impersonate IT support, SARS, or courier services to trick you.\n" +
            "  • Always verify the caller's identity through official channels.\n" +
            "  • Never share OTPs, PINs, or passwords over the phone.\n" +
            "  • Be sceptical of unexpected offers, prizes, or urgent requests.\n" +
            "  • When in doubt, hang up and call the organisation's official number."),

        (new[]{ "privacy", "personal data", "popia", "data protection" },
            " PRIVACY & POPIA:\n" +
            "  • South Africa's Protection of Personal Information Act (POPIA) gives you rights.\n" +
            "  • Limit the personal info you share on social media.\n" +
            "  • Read privacy policies before signing up for services.\n" +
            "  • Opt out of marketing communications you did not consent to.\n" +
            "  • Report POPIA violations to the Information Regulator SA."),

        (new[]{ "2fa", "two factor", "two-factor", "mfa", "multi factor", "authentication" },
            " TWO-FACTOR AUTHENTICATION (2FA):\n" +
            "  • 2FA adds a second verification step beyond your password.\n" +
            "  • Use an authenticator app (Google Authenticator, Authy) rather than SMS when possible.\n" +
            "  • Enable 2FA on email, banking, and social media accounts.\n" +
            "  • Store backup codes in a safe, offline location."),

        (new[]{ "bye", "goodbye", "exit", "quit" },
            "QUIT_SIGNAL"),
    };

    /// <summary>Returns the best matching response, or null if the user wants to quit.</summary>
    public static string? GetResponse(string input, string userName)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "I didn't catch anything there. Could you rephrase your question?";

        string normalised = input.ToLowerInvariant().Trim();

        foreach (var (keywords, response) in ResponseMap)
        {
            foreach (string kw in keywords)
            {
                if (normalised.Contains(kw))
                {
                    if (response == "QUIT_SIGNAL") return null;
                    return response.Replace("{name}", userName);
                }
            }
        }

        return $"I'm not sure I understand that, {userName}. " +
               "Try asking about: passwords, phishing, malware, safe browsing, privacy, 2FA, or type 'help'.";
    }

    private static string BuildHelpText() =>
        "  HERE'S WHAT I CAN HELP WITH:\n" +
        "  • passwords       — Safe password practices\n" +
        "  • phishing        — Spotting and avoiding phishing scams\n" +
        "  • safe browsing   — Staying safe while browsing the web\n" +
        "  • malware         — Protecting against viruses and ransomware\n" +
        "  • social engineering — Recognising manipulation tactics\n" +
        "  • privacy / POPIA — Your data rights in South Africa\n" +
        "  • 2FA             — Two-factor authentication\n" +
        "  • how are you     — Just for fun \n" +
        "  • quit / bye      — Exit the chatbot";
}