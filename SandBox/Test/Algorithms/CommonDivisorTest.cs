using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SandBox.Algorithms;
using SandBox.Utils;

namespace SandBox.Test.Algorithms
{
    [TestFixture]
    public class CommonDivisorTest
    {
        private List<int> SampleSequence1 = new List<int> { -3, 25, 75, 0, 125 };
        private List<int> SampleSequence25 = new List<int> { 25, 75, 125 };
        private List<int> SampleSequence157 = new List<int> { 314, 471, 1727 };

        public async Task GenericCommonDivisorTest(CommonDivisionType commonDivisionType, IList<int> sequence, int expected)
        {
            var commonDivisor = new CommonDivisor();

            var randomSequence = new List<int>();
            randomSequence.AddRange(sequence);

            var result = await commonDivisor.StartAndReturnResult(randomSequence, commonDivisionType).ConfigureAwait(false);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public async Task NaiveTest1()
            => await GenericCommonDivisorTest(CommonDivisionType.Naive, SampleSequence1, 1).ConfigureAwait(false);

        [Test]
        public async Task FactorizationTest1()
            => await GenericCommonDivisorTest(CommonDivisionType.Factorization, SampleSequence1, 1).ConfigureAwait(false);

        [Test]
        public async Task NaiveTest25()
            => await GenericCommonDivisorTest(CommonDivisionType.Naive, SampleSequence25, 25).ConfigureAwait(false);

        [Test]
        public async Task FactorizationTest25()
            => await GenericCommonDivisorTest(CommonDivisionType.Factorization, SampleSequence25, 25).ConfigureAwait(false);

        [Test]
        public async Task NaiveTest157()
            => await GenericCommonDivisorTest(CommonDivisionType.Naive, SampleSequence157, 157).ConfigureAwait(false);

        [Test]
        public async Task FactorizationTest157()
            => await GenericCommonDivisorTest(CommonDivisionType.Factorization, SampleSequence157, 157).ConfigureAwait(false);
    }
}
