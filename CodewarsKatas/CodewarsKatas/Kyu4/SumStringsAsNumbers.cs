using System.Linq;
using System.Numerics;
using System.Text;

namespace CodewarsKatas.CodewarsKatas.Kyu4
{
	//https://www.codewars.com/kata/sum-strings-as-numbers/train/csharp
	internal class SumStringsAsNumbers
	{
		public static string sumStrings(string a, string b)
		{
			if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b)) return string.Empty;

			var validationSet = "0123456789";
			foreach (var c in a)
				if (!validationSet.Contains(c)) return string.Empty;
			foreach (var c in b)
				if (!validationSet.Contains(c)) return string.Empty;

			return (BigInteger.Parse(a) + BigInteger.Parse(b)).ToString();
		}

		public static string sumStringsByChars(string a, string b)
		{
			var result = new StringBuilder();
			var buff = 0D;
			if (a.Length < b.Length)
				a = a.PadLeft(b.Length, '0');
			if (b.Length < a.Length)
				b = b.PadLeft(a.Length, '0');

			for (int i = a.Length - 1; i >= 0; i--)
			{
				result.Insert(0, SumChars(a[i], b[i], ref buff));
			}

			if (buff != 0)
				result.Insert(0, buff);

			while (result[0].Equals('0'))
				result.Remove(0, 1);

			return result.ToString();
		}

		private static double SumChars(char a, char b, ref double buff)
		{
			var sum = char.GetNumericValue(a) + char.GetNumericValue(b) + buff;
			buff = sum > 9 ? 1 : 0;
			return sum > 9 ? sum - 10 : sum;
		}
	}
}