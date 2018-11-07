using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SandBox.CodewarsKatas.Kyu4;
using SandBox.CodewarsKatas.WIP;

namespace SandBox.CodewarsKatas.Tests.Kyu4
{
    [TestFixture]
    class NextBiggerNumberWithSameDigitsTest
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(21, NextBiggerNumberWithSameDigits.NextBiggerNumber(12));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(531, NextBiggerNumberWithSameDigits.NextBiggerNumber(513));
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual(2071, NextBiggerNumberWithSameDigits.NextBiggerNumber(2017));
        }

        [Test]
        public void Test4()
        {
            Assert.AreEqual(441, NextBiggerNumberWithSameDigits.NextBiggerNumber(414));
        }

        [Test]
        public void Test5()
        {
            Assert.AreEqual(414, NextBiggerNumberWithSameDigits.NextBiggerNumber(144));
        }

        [Test]
        public void Test6()
        {
            Assert.AreEqual(-1, NextBiggerNumberWithSameDigits.NextBiggerNumber(531));
        }

        [Test]
        public void Test7()
        {
            Assert.AreEqual(312, NextBiggerNumberWithSameDigits.NextBiggerNumber(231));
        }
    }
}
