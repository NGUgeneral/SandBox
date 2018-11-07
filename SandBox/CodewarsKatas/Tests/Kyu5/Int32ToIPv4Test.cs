using System;
using NUnit.Framework;
using SandBox.CodewarsKatas.Kyu5;

namespace SandBox.CodewarsKatas.Tests.Kyu5
{
    [TestFixture]
    public class Int32ToIPv4Test
    {
        [Test, Description("Sample Tests")]
        public void Test()
        {
            Assert.AreEqual("128.114.17.104", Int32ToIPv4.UInt32ToIP(2154959208));
            Assert.AreEqual("0.0.0.0", Int32ToIPv4.UInt32ToIP(0));
            Assert.AreEqual("128.32.10.1", Int32ToIPv4.UInt32ToIP(2149583361));
        }
    }
}
