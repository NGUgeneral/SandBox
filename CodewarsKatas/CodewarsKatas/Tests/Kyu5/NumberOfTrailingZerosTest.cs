using CodewarsKatas.CodewarsKatas.Kyu5;
using NUnit.Framework;

namespace CodewarsKatas.CodewarsKatas.Tests.Kyu5
{
    [TestFixture]
    class NumberOfTrailingZerosTest
    {
        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 5)]
        [TestCase(2, 10)]
        [TestCase(2, 12)]
        [TestCase(3, 15)]
        [TestCase(6, 25)]
        [TestCase(131, 531)]
        public void BasicTests(int expected, int n)
        {
            Assert.AreEqual(expected, NumberOfTrailingZeros.Run(n));
        }
    }
}
