using System;
using System.Collections.Generic;
using SandBox.Algorithms;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            //var sort = new Sort<int>();
            var commonDivisor = new CommonDivisor();

            //var sample = new List<int> { 12, 16, 24 };
            var sample = Helpers.GetRandomIntSequence(1, 10000);
            var randomSequence = new List<int>();

            randomSequence.AddRange(sample);

            Helpers.RunWithTimeBenchmark(commonDivisor.Start, randomSequence, CommonDivisionType.Factorization);

            #region sortingAlgorithms


            //Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.QuickRecursiveMemoryLeaky);

            //randomSequence.Clear();
            //randomSequence.AddRange(sample);

            //Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.MergeTimeCost);

            //randomSequence.Clear();
            //randomSequence.AddRange(sample);

            //Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.MergeMemoryCost);

            //randomSequence.Clear();
            //randomSequence.AddRange(sample);

            //Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.HeapTimeCost);

            //randomSequence.Clear();
            //randomSequence.AddRange(sample);

            //Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.Selection);

            //randomSequence.Clear();
            //randomSequence.AddRange(sample);

            //Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.Insertion);

            //randomSequence.Clear();
            //randomSequence.AddRange(sample);

            //Helpers.RunWithTimeBenchmark(sort.StartAndValidate, randomSequence, SortType.Bubble);

            #endregion

            randomSequence.Clear();
            sample.Clear();

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
