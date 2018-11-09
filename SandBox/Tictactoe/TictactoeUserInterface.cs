using System;

namespace SandBox.Tictactoe
{
    class TictactoeUserInterface
    {
        public TictactoeUserInterface()
        {
            new TictactoeProcessor();

            Console.WriteLine("\n");
            Console.WriteLine("Press any key to exit ...");
            Console.ReadLine();
        }
    }
}
