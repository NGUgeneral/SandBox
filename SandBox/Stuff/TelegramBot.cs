using System;
using Telegram.Bot;

namespace SandBox.Stuff
{
	class TelegramBot
	{
		public void Start()
		{
			var bot = new TelegramBotClient("875561286:AAFGj_P2jZAyLnuDjOLoiHjXlQ4dShiBcr8");

			bot.StartReceiving();

			bot.OnMessage += async (sender, args) =>
			{
				var chat = args.Message.Chat;
				Console.WriteLine($@"Received a message from : {args.Message.From.Username}" + "\n");
				await bot.SendTextMessageAsync(chat.Id, $@"Hi am am a parrot bot. And you said: {args.Message.Text}");
			};

			Console.WriteLine("\nPress any key to stop the bot ...");
			Console.ReadKey();

			bot.StopReceiving();
		}


	}
}
