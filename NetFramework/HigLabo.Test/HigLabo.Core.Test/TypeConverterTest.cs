using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HigLabo.Core.Test
{
    [TestClass]
    public class TypeConverterTest
    {
        public enum CaseSensitiveEnum
        {
            V1,
            v1,
        }
        [TestMethod]
        public void BasicEnumTest()
        {
            Assert.AreEqual("Friday".ToEnum(typeof(DayOfWeek)), DayOfWeek.Friday);
            Assert.AreEqual("Saturday".ToEnum(typeof(DayOfWeek)), DayOfWeek.Saturday);
            Assert.AreEqual("saturday".ToEnum(typeof(DayOfWeek)), DayOfWeek.Saturday);
            Assert.AreEqual("saturday".ToEnum(typeof(DayOfWeek), StringComparison.Ordinal), null);
            Assert.AreEqual("Day".ToEnum(typeof(DayOfWeek), StringComparison.Ordinal), null);
        }
        [TestMethod]
        public void CaseSensitiveEnumTest()
        {
            Assert.AreEqual("V1".ToEnum(typeof(CaseSensitiveEnum), StringComparison.Ordinal), CaseSensitiveEnum.V1);
            Assert.AreEqual("v1".ToEnum(typeof(CaseSensitiveEnum), StringComparison.Ordinal), CaseSensitiveEnum.v1);

            Assert.AreEqual("v1".ToEnum(typeof(CaseSensitiveEnum)), CaseSensitiveEnum.V1);
            Assert.AreEqual("V1".ToEnum(typeof(CaseSensitiveEnum)), CaseSensitiveEnum.V1);//Match first one...
        }
    }
}
