namespace CybersecurityChatbot;

/// <summary>
/// Plays a WAV voice greeting on application launch.
/// Falls back gracefully on non-Windows or missing file.
/// </summary>
internal static class AudioPlayer
{
    private const string WavFileName = "greeting.wav.wav";

    public static void PlayGreeting()
    {
        string wavPath = Path.Combine(AppContext.BaseDirectory, WavFileName);

        if (!File.Exists(wavPath))
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"[Audio] Voice greeting file not found at: {wavPath}");
            Console.ResetColor();
            return;
        }

        try
        {
            if (OperatingSystem.IsWindows())
                PlayWavWindows(wavPath);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"[Audio] Could not play greeting: {ex.Message}");
            Console.ResetColor();
        }
    }

    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    private static void PlayWavWindows(string path)
    {
        using var player = new System.Media.SoundPlayer(path);
        player.PlaySync();
    }
}