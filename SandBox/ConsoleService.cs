using System;
using SandBox.Stuff;

namespace SandBox
{
	internal class ConsoleService
	{
		public ConsoleService()
		{
			//var bot = new TelegramBot();
			//bot.Start();

			var tournamentManager = new TournamentManager();
			tournamentManager.Start(8, 8);

			Console.WriteLine("\nPress any key to exit ...");
			Console.ReadKey();
		}
	}
}