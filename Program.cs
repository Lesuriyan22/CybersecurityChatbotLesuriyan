using CybersecurityChatbot;

// Entry point: orchestrate startup sequence
AudioPlayer.PlayGreeting();
DisplayHelper.ShowBanner();

var user = UserSession.InitialiseSession();
var bot = new ChatBot(user);
bot.Run();