using System;
using System.Collections.Generic;
using System.Linq;

namespace SandBox.Sorting
{
    public static class Helpers
    {
        public static List<int> GetRandomIntSequence(int min, int max)
        {
            if (max < min)
            {
                var temp = max;
                max = min;
                min = temp;
            }
            else if (max == min) max++;

            var r = new Random();
            var result = Enumerable.Range(min, max - min + 1).ToList();

            for(int i = 0; i < result.Count; i++)
                result.Swap(i, r.Next(i, result.Count));

            return result;
        }

        public static List<int> GetRandomIntSequenceWithEquals(int min, int max)
        {
            var r = new Random();
            var result = new List<int>();
            for (int i = 0; i < max; i++)
            {
                result.Add(r.Next(min, max));
            }

            return result;
        }

        public static void Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            if(indexA.Equals(indexB))return;

            var temp = list[indexB];
            list[indexB] = list[indexA];
            list[indexA] = temp;
        }

        public static void MoveTo<T>(this IList<T> list, int iOld, int iNew)
        {
            if (iOld.Equals(iNew)) return;
            var temp = list[iOld];
            list.RemoveAt(iOld);
            list.Insert(iNew, temp);
        }

        public static bool ValidateSequence<T>(this IList<T> sequence) where T : IComparable
        {
            if (sequence == null) throw new NullReferenceException("Can't validate a null sequence order");
            if (sequence.Count == 1) return true;

            for (int i = 1; i < sequence.Count; i++)
                if (sequence[i].CompareTo(sequence[i - 1]) < 0) return false;

            return true;
        }

        public static void RunWithTimeBenchmark<T1, T2>(Action<T1, T2> action, T1 input1, T2 input2)
        {
            var start = DateTime.Now;

            action?.Invoke(input1, input2);

            var elapsed = DateTime.Now - start;
            Console.WriteLine($"{elapsed.Minutes}m:{elapsed.Seconds}s:{elapsed.Milliseconds}ms\n");
        }
    }
}
