using System;

namespace SandBox.Tictactoe
{
    class TictactoeUserInterface
    {
        public TictactoeUserInterface()
        {
            new TictactoeProcessor(5);

            Console.WriteLine("\n");
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
