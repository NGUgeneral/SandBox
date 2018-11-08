using System.Numerics;
using NUnit.Framework;
using SandBox.CodewarsKatas.WIP;

namespace SandBox.CodewarsKatas.Tests.Kyu3
{
    [TestFixture]
    class MillionthFibonacciKataTest
    {
        [Test]
        public void TestFib0()
        {
            TestFib(0, 0);
        }

        [Test]
        public void TestFib1()
        {
            TestFib(1, 1);
        }

        [Test]
        public void TestFib2()
        {
            TestFib(1, 2);
        }

        [Test]
        public void TestFib3()
        {
            TestFib(2, 3);
        }

        [Test]
        public void TestFib4()
        {
            TestFib(3, 4);
        }

        [Test]
        public void TestFib5()
        {
            TestFib(5, 5);
        }

        [Test]
        public void TestFib10()
        {
            TestFib(55, 10);
        }

        [Test]
        public void TestFib20()
        {
            TestFib(6765, 20);
        }

        [Test]
        public void TestFib30()
        {
            TestFib(832040, 30);
        }

        [Test]
        public void TestFib40()
        {
            TestFib(102334155, 40);
        }

        [Test]
        public void TestFib50()
        {
            TestFib(12586269025, 50);
        }

        private static void TestFib(long expected, int input)
        {
            BigInteger found = MillionthFibonacciKata.Fib(input);
            Assert.AreEqual(new BigInteger(expected), found);
        }
    }
}
