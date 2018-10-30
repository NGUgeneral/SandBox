using SandBox.Algorithms;
using SandBox.Math;
using SandBox.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SandBox
{
    class ConsoleService
    {
        public ConsoleService()
        {
            var factorHelper = new Factorization();
            var sort = new Sort<int>();
            var sequenceSample = Helpers.GetRandomIntSequence(1, 100);
            var randomSequence = new List<int>();

            randomSequence.AddRange(sequenceSample);
            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.MergeMemoryCost);
            randomSequence.Clear();

            randomSequence.AddRange(sequenceSample);
            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.MergeTimeCost);
            randomSequence.Clear();

            randomSequence.AddRange(sequenceSample);
            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.QuickRecursiveMemoryLeaky);
            randomSequence.Clear();

            randomSequence.AddRange(sequenceSample);
            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.HeapTimeCost);
            randomSequence.Clear();

            randomSequence.AddRange(sequenceSample);
            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.Bubble);
            randomSequence.Clear();

            randomSequence.AddRange(sequenceSample);
            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.Selection);
            randomSequence.Clear();

            randomSequence.AddRange(sequenceSample);
            Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.Insertion);
            randomSequence.Clear();

            var commonDivisor = new CommonDivisor();
            var sequence = new List<int> { -3, 25, 75, 0, 125 };

            commonDivisor.Start(sequence, CommonDivisionType.Factorization);

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
