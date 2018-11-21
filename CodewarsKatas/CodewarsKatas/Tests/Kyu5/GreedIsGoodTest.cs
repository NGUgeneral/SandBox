using CodewarsKatas.CodewarsKatas.Kyu5;
using NUnit.Framework;

namespace CodewarsKatas.CodewarsKatas.Tests.Kyu5
{
	[TestFixture]
	internal class GreedIsGoodTest
	{
		[Test]
		[TestCase(new int[] { 2, 3, 4, 6, 2 }, 0)]
		[TestCase(new int[] { 4, 4, 4, 3, 3 }, 400)]
		[TestCase(new int[] { 2, 4, 4, 5, 4 }, 450)]
		public static void GenericScoreCheck(int[] dices, int expected)
		{
			var score = GreedIsGood.Score(dices);
			Assert.AreEqual(expected, score, $"Should be {expected}, but was {score}");
		}
	}
}