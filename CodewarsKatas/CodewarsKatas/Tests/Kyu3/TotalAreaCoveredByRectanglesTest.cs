using System.Linq;
using CodewarsKatas.CodewarsKatas.WIP.Kyu3;
using NUnit.Framework;

namespace CodewarsKatas.CodewarsKatas.Tests.Kyu3
{
    [TestFixture]
    class TotalAreaCoveredByRectanglesTest
    {
        [Test]
        public void ZeroRectangles()
        {
            Assert.AreEqual(0, TotalAreaCoveredByRectangles.Calculate(Enumerable.Empty<int[]>()));
        }

        [Test]
        public void OneRectangle()
        {
            Assert.AreEqual(1, TotalAreaCoveredByRectangles.Calculate(new[] { new[] { 0, 0, 1, 1 } }));
        }

        [Test]
        public void OneRectangleV2()
        {
            Assert.AreEqual(22, TotalAreaCoveredByRectangles.Calculate(new[] { new[] { 0, 4, 11, 6 } }));
        }

        [Test]
        public void TwoRectangles()
        {
            Assert.AreEqual(2, TotalAreaCoveredByRectangles.Calculate(new[] { new[] { 0, 0, 1, 1 }, new[] { 1, 1, 2, 2 } }));
        }

        [Test]
        public void TwoRectanglesV2()
        {
            Assert.AreEqual(4, TotalAreaCoveredByRectangles.Calculate(new[] { new[] { 0, 0, 1, 1 }, new[] { 0, 0, 2, 2 } }));
        }

        [Test]
        public void ThreeRectangles()
        {
            Assert.AreEqual(36, TotalAreaCoveredByRectangles.Calculate(new[] { new[] { 3, 3, 8, 5 }, new[] { 6, 3, 8, 9 }, new[] { 11, 6, 14, 12 } }));
        }

        //[Test]
        //[TestCase(new[]{0,0,0,0}, 0)]
        //[TestCase(new[]{0,0,1,1}, 1)]
        //[TestCase(new[]{0,0,2,2}, 4)]
        //[TestCase(new[]{0,0,2,1}, 2)]

        //public void CalculateRectangleAreaTest(int[] rectangle, long expected)
        //{
        //    Assert.AreEqual(expected, TotalAreaCoveredByRectangles.CalculateRectangleArea(rectangle));
        //}

        //[Test]
        //[TestCase(new[] { 0, 0, 1, 1 }, new[] { 2, 2, 3, 3 }, null)]
        //[TestCase(new[] { 2, 2, 3, 3 }, new[] { 2, 2, 4, 4 }, new[] { 2, 2, 3, 3 })]
        //[TestCase(new[] { 6, 0, 8, 4 }, new[] { 7, 1, 11, 3 }, new[] { 7, 1, 8, 3 })]
        //[TestCase(new[] { 2, 1, 4, 5 }, new[] { 1, 2, 5, 4 }, new[] { 2, 2, 4, 4 })]
        //[TestCase(new[] { 0, 0, 2, 2 }, new[] { 1, 1, 3, 3 }, new[] { 1, 1, 2, 2 })]
        //[TestCase(new[] { 0, 1, 2, 3 }, new[] { 1, 0, 3, 2 }, new[] { 1, 1, 2, 2 })]

        //public void GetIntersectionRectangleTest(int[] r1, int[] r2, int[] expected)
        //{
        //    Assert.AreEqual(expected, TotalAreaCoveredByRectangles.GetIntersectionRectangle(r1, r2));
        //}
    }
}
