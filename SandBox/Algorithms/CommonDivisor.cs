using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox.Algorithms
{
    class CommonDivisor
    {
        public void Start(IList<int> sequence, CommonDivisionType algorithm)
        {
            Console.WriteLine($"Algorithm: {algorithm}");
            Console.WriteLine($"Attempt to find greatest common divisor of {sequence.Count:n0} elements ...");
            StartHandler(sequence, algorithm);
        }

        public void StartHandler(IList<int> sequence, CommonDivisionType algorithm)
        {
            if (sequence == null) throw new NullReferenceException("Can't find common divisor for a null sequence");
            var result = 0;

            if (sequence.Count == 1)
            {
                result = sequence[0];
            }
            else
            {
                switch (algorithm)
                {
                    case CommonDivisionType.Naive:
                        result = Naive(sequence);
                        break;
                    case CommonDivisionType.Euclidean:
                        result = Euclidean(sequence);
                        break;
                    case CommonDivisionType.Factorization:
                        result = Factorization(sequence);
                        break;
                }
            }

            Console.WriteLine($"Greatest common divisor for a given sequence is: {result}");
        }

        #region Naive

        private static int Naive(IList<int> sequence)
        {
            int i = sequence.Max() - 1;
            while(i > 0)
            {
                foreach (var num in sequence)
                    if (num != 0 && ValidateCommonDivision(sequence, i)) return i;

                i--;
            }

            return 0;
        }

        private static bool ValidateCommonDivision(IList<int> sequence, int i)
        {
            foreach (var num in sequence)
                if (num % i != 0) return false;

            return true;
        }

        #endregion

        #region Factorization

        //This implementation is about:
        //1. Factorize each given number of a set (including the number itself).
        //2. Determine the greatest common element.

        private static int Factorization(IList<int> sequence)
        {
            Console.WriteLine("This algorithm is not implemented yet!");
            return 0;
        }

        #endregion

        #region Euclidean

        private static int Euclidean(IList<int> sequence)
        {
            Console.WriteLine("This algorithm is not implemented yet!");
            return 0;
        }

        #endregion
    }
}
