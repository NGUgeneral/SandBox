using CodewarsKatas.CodewarsKatas.Kyu5;
using NUnit.Framework;

namespace CodewarsKatas.CodewarsKatas.Tests.Kyu5
{
    [TestFixture]
    public class WeightForWeightTest
    {
        [TestCase("2000 103 123 4444 99", "103 123 4444 99 2000")]
        [TestCase("11 11 2000 10003 22 123 1234000 44444444 9999", "2000 10003 1234000 44444444 9999 11 11 22 123")]
        public void Test(string expected, string input)
        {
            Assert.AreEqual(expected, WeightForWeight.OrderWeight(input));
        }
    }
}
