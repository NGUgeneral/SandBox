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

            //var sample = new List<int>{ 9, 4, 2, 8, 1, 0, 6, 7, 3, 5 };
            var sample = Helpers.GetRandomIntSequence(1, 10000);
            var randomSequence = new List<int>();

            randomSequence.AddRange(sample);

            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.QuickRecursiveMemoryLeaky);

            randomSequence.Clear();
            randomSequence.AddRange(sample);

            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.MergeTimeCost);

            randomSequence.Clear();
            randomSequence.AddRange(sample);

            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.MergeMemoryCost);

            randomSequence.Clear();
            randomSequence.AddRange(sample);

            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.Selection);

            randomSequence.Clear();
            randomSequence.AddRange(sample);

            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.Insertion);

            randomSequence.Clear();
            randomSequence.AddRange(sample);

            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.Bubble);

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
