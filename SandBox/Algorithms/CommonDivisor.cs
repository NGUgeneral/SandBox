using SandBox.Algorithms.MathOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandBox.Algorithms
{
	internal class CommonDivisor
	{
		public async Task<int> StartAndReturnResult(IList<int> sequence, CommonDivisionType algorithm)
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
						result = await Naive(sequence).ConfigureAwait(false);
						break;

					case CommonDivisionType.Euclidean:
						result = Euclidean(sequence);
						break;

					case CommonDivisionType.Factorization:
						result = await Factorization(sequence).ConfigureAwait(false);
						break;
				}
			}

			return result;
		}

		#region Naive

		private async Task<int> Naive(IList<int> sequence)
		{
			int i = sequence.Max() - 1;
			while (i > 0)
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

		#endregion Naive

		#region Factorization

		private async Task<int> Factorization(IList<int> sequence)
		{
			if (!sequence.Any()) return 0;
			if (sequence.Count == 1) return sequence.Max();

			var factorService = new Factorization();
			var factorizedSequence = new List<List<int>>();

			foreach (var number in new HashSet<int>(sequence))
			{
				var factor = factorService.Factorize(number);
				if (factor.Any()) factorizedSequence.Add(factor);
			}

			var commonDivisors = IntersectFactors(factorizedSequence[0], factorizedSequence[1]);

			for (int i = 2; i < factorizedSequence.Count; i++)
				commonDivisors = IntersectFactors(commonDivisors, factorizedSequence[i]);

			return commonDivisors.Any() ? commonDivisors.Aggregate((x, y) => x * y) : 1;
		}

		private static IEnumerable<int> IntersectFactors(IEnumerable<int> seq1, IEnumerable<int> seq2)
		{
			foreach (var prime in seq1.Intersect(seq2).ToArray())
			{
				var count = System.Math.Min(seq1.Count(x => x == prime), seq2.Count(x => x == prime));

				for (int i = 0; i < count; i++)
					yield return prime;
			}
		}

		#endregion Factorization

		#region Euclidean

		private static int Euclidean(IList<int> sequence)
		{
			Console.WriteLine("This algorithm is not implemented yet!");
			return 0;
		}

		#endregion Euclidean
	}
}