using System.Collections.Generic;
using System.Linq;
using SandBox.Utils;

namespace SandBox.Math
{
    public sealed class Factorization : JsonCacheService<List<int>>
    {
        public List<int> Primes => _obj;
        public Factorization() : base(new List<int> { 2 }, "primes")
        {
            Load();
        }

        public int GetPrime(int i)
        {
            var needSave = false;
            while (Primes.Count < i)
            {
                GetNextPrime();
                if (!needSave) needSave = true;
            }
            
            if (needSave) Save();
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
            
            if (needSave) Save();

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