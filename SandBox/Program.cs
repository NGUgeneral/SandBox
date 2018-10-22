using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using NUnit.Framework.Constraints;
using SandBox.Items;
using SandBox.Sorting;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var sort = new Sort<int>();
            var sample = Helpers.GetRandomIntSequence(1, 100000);
            var randomSequence = new List<int>();
            randomSequence.AddRange(sample);

            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.MergeMemoryCost);

            randomSequence.Clear();
            randomSequence.AddRange(sample);

            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.MergeTimeCost);

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
