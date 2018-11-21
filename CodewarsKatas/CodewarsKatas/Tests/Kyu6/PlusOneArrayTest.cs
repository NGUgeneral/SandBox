using CodewarsKatas.CodewarsKatas.Kyu6;
using NUnit.Framework;

namespace CodewarsKatas.CodewarsKatas.Tests.Kyu6
{
	[TestFixture]
	internal class PlusOneArrayTest
	{
		[Test]
		[TestCase(new[] { 2, 4, 0 }, new[] { 2, 3, 9 })]
		[TestCase(new[] { 1, 0, 0, 0 }, new[] { 9, 9, 9 })]
		[TestCase(new[] { 4, 3, 2, 6 }, new[] { 4, 3, 2, 5 })]
		[TestCase(new int[] { }, new int[] { })]
		[TestCase(null, null)]
		public void Test(int[] expected, int[] arg)
		{
			Assert.AreEqual(expected, PlusOneArray.Run(arg));
		}
	}
}