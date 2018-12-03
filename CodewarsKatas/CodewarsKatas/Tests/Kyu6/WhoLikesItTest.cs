using CodewarsKatas.CodewarsKatas.Kyu6;
using NUnit.Framework;

namespace CodewarsKatas.CodewarsKatas.Tests.Kyu6
{
  [TestFixture]
  class WhoLikesItTest
  {
    [Test, Description("It should return correct text")]
    [TestCase("no one likes this", new string[0])]
    [TestCase("Peter likes this", new [] {"Peter"})]
    [TestCase("Jacob and Alex like this", new [] {"Jacob", "Alex"})]
    [TestCase("Max, John and Mark like this", new [] {"Max", "John", "Mark"})]
    [TestCase("Alex, Jacob and 2 others like this", new [] {"Alex", "Jacob", "Mark", "Max"})]
    public void SampleTest(string expected, string[] input)
    {
      Assert.AreEqual(expected, WhoLikesIt.Run(input));
    }
  }
}
