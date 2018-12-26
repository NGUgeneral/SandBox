using CodewarsKatas.CodewarsKatas.Kyu6;
using NUnit.Framework;

namespace CodewarsKatas.CodewarsKatas.Tests.Kyu6
{
  [TestFixture]
  class SimpleFun79Test
  {
    [Test]
    public void BasicTests1()
    {
      Assert.AreEqual(52,SimpleFun79.DeleteDigit(152));
    }

    [Test]
    public void BasicTests2()
    {
      Assert.AreEqual(101,SimpleFun79.DeleteDigit(1001));
    }

    [Test]
    public void BasicTests3()
    {
      Assert.AreEqual(1,SimpleFun79.DeleteDigit(10));
    }
  }
}
