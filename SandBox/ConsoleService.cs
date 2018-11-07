using System;
using System.Collections.Generic;
using SandBox.Math;

namespace SandBox
{
    class ConsoleService
    {
        public ConsoleService()
        {   

            Factorization factorization = new Factorization();
            var result = new List<int>();
            foreach (var prime in factorization.Factorize(121))
                result.Add(prime);

            Console.WriteLine(string.Join("*", result));

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
