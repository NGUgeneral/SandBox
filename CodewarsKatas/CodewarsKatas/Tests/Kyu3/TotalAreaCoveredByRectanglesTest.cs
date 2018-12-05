using System.Linq;
using System.Text;
using CodewarsKatas.CodewarsKatas.WIP.Kyu3;
using NUnit.Framework;

namespace CodewarsKatas.CodewarsKatas.Tests.Kyu3
{
	[TestFixture]
	internal class TotalAreaCoveredByRectanglesTest
	{
    [Test]
	  public void TestCase1_SimpleIntersection()
	  {
	    int[][] rectangles = { new[] { 1, 1, 3, 3 }, new[] { 2, 2, 4, 4 } };
	    Assert.AreEqual(7, TotalAreaCoveredByRectangles.Run(rectangles));
	  }

	  [Test]
	  public void TestCase2_NoIntersection()
	  {
	    int[][] rectangles = { new[] { 1, 2, 4, 5 }, new[] { 4, 3, 9, 4 }, new [] { 10, 2, 11, 5 } };
	    Assert.AreEqual(17, TotalAreaCoveredByRectangles.Run(rectangles));
	  }
	  [Test]
	  public void TestCase3_ComplexIntersection1()
	  {
	    int[][] rectangles = { new[] { 2, 2, 4, 4 }, new[] { 2, 3, 4, 5 }, new [] { 3, 3, 5, 5 } };
	    Assert.AreEqual(8, TotalAreaCoveredByRectangles.Run(rectangles));
	  }
	  [Test]
	  public void TestCase4_ComplexIntersection2()
	  {
	    int[][] rectangles = { new[] { 1, 1, 6, 6 }, new[] { 2, 2, 5, 5 }, new [] { 3, 3, 4, 7 } };
	    Assert.AreEqual(26, TotalAreaCoveredByRectangles.Run(rectangles));
	  }
  }

  [TestFixture]
  internal class CalculateSingleRectangleAreaTest
  {
    [TestCase(4, new[]{ 1, 1, 3, 3 })]
    [TestCase(25, new[] { 0, 1, 5, 6 })]
    public void RunTest(long expected, int[] rectangle)
    {
      Assert.AreEqual(expected, TotalAreaCoveredByRectangles.GetRectangleArea(rectangle));
    }
  }

  [TestFixture]
  internal class CutOutRectangleTest
  {
    [TestCase("0,0,2,4;2,0,3,3;", new[]{ 0, 0, 3, 4 }, new[] { 2, 3, 6, 5 })]
    [TestCase("0,0,1,2;1,0,2,1;", new[]{ 0, 0, 2, 2 }, new[] { 1, 1, 3, 3 })]
    public void RunTest(string expected, int[] rectangle, int[] blade)
    {
      var result = new StringBuilder();
      var split = TotalAreaCoveredByRectangles.CutOutRectangle(rectangle, blade);
      foreach (var r in split)
      {
        foreach (var i in r)
          result.Append(i);

        result.Append(';');
      }

      Assert.AreEqual(expected, result.ToString());
    }
  } 
}