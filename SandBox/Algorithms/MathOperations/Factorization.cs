using System.Collections.Generic;
using System.IO;
using System.Linq;
using SandBox.Utils;

namespace SandBox.Algorithms.MathOperations
{
    public sealed class Factorization
    {
        private List<int> _primes { get; } = new List<int> { 2 };
        public List<int> Primes => _primes;
        public Factorization()
        {
            if(File.Exists("primes"))
                _primes = PersistantSerializer<List<int>>.Load("primes");
        }

        public int GetPrime(int i)
        {
            var needSave = false;
            while (Primes.Count < i)
            {
                GetNextPrime();
                if (!needSave) needSave = true;
            }
            
            if (needSave)
                PersistantSerializer<List<int>>.Save("primes", _primes);
            return Primes[i - 1];
        }

        private int GetPrimeBefore(int lim)
        {
            var needSave = false;

            while (Primes.Last() < lim)
            {
                GetNextPrime();
                if (!needSave) needSave = true;
            }
            
            if (needSave)
                PersistantSerializer<List<int>>.Save("primes", _primes);

            return Primes.LastOrDefault(x => x <= lim);
        }

        private void GetNextPrime()
        {
            var n = Primes.Last() + 1;
            while (!IsPrime(n))
                n++;
            Primes.Add(n);
        }

        private bool IsPrime(int n)
            => Primes.FirstOrDefault(x => n % x == 0) == 0;

        public List<int> Factorize(int n)
        {
            var result = new List<int>();
            if (n < 2 || Primes.Contains(n)) return new List<int>{ n };
            var i = Primes.IndexOf(GetPrimeBefore(n));


            while (n != 1)
            {
                if (n % Primes[i] == 0)
                {
                    result.Add(Primes[i]);
                    n /= Primes[i];
                }
                else
                {
                    i--;
                }
            }

            return result;
        }
    }
}