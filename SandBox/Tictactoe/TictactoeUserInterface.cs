using System;

namespace SandBox.Tictactoe
{
    class TictactoeUserInterface
    {
        public TictactoeUserInterface()
        {
            TictactoeProcessor.StartGame(3);

            Console.WriteLine("\n");
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
