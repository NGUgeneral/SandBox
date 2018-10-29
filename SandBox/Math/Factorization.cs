using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SandBox.Utils;

namespace SandBox.Math
{
    public sealed class Factorization : LocalSave<List<int>>
    {
        private List<int> Primes => _obj;
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

            if(needSave) Save();
            return Primes[i - 1];
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
    }
}
