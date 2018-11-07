﻿using System;
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
    public class SumStringsAsNumbersTest
    {
        [Test]
        public void Given123And456Returns579()
        {
            Assert.AreEqual("579", SumStringsAsNumbers.sumStrings("123", "456"));
        }

        [Test]
        public void Given111And11Returns122()
        {
            Assert.AreEqual("122", SumStringsAsNumbers.sumStrings("111", "11"));
        }

        [Test]
        public void Given155And55Returns210()
        {
            Assert.AreEqual("210", SumStringsAsNumbers.sumStrings("155", "55"));
        }

        [Test]
        public void Given967And53Returns1020()
        {
            Assert.AreEqual("1020", SumStringsAsNumbers.sumStrings("967", "53"));
        }
    }
}
