using System;
using System.CodeDom;
using System.Linq;

namespace CodewarsKatas.CodewarsKatas.Kyu5
{
    //https://www.codewars.com/kata/weight-for-weight/train/csharp
    public class WeightForWeight
    {
        public static string OrderWeight(string input)
        {
            var weightIntValues = input.Split().Select(x => new WeightInt(x)).OrderBy(x => x).Select(x => x.Value).ToArray();
            return string.Join(" ", weightIntValues);
        }

        private static int Weight(string input)
        {
            var result = 0;

            for (int i = 0; i < input.Length; i++)
                result += (int)char.GetNumericValue(input[i]);

            return result;
        }

        private class WeightInt : IComparable
        {
            private int Weight { get; }
            public string Value { get; }

            public WeightInt(string value)
            {
                Value = value;
                Weight = Weight(value);
            }

            public int CompareTo(object obj)
            {
                var other = (WeightInt) obj;

                if (other.Weight > this.Weight)
                    return -1;
                if (other.Weight < this.Weight)
                    return 1;
                if (int.Parse(other.Value) > int.Parse(this.Value))
                    return -1;
                if (int.Parse(other.Value) < int.Parse(this.Value))
                    return 1;

                return 0;
            }
        }
    }
}
