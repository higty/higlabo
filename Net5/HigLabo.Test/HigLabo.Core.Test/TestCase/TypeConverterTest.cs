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
            Assert.AreEqual("Friday".ToEnum<DayOfWeek>(), DayOfWeek.Friday);
            Assert.AreEqual("Saturday".ToEnum<DayOfWeek>(), DayOfWeek.Saturday);
            Assert.AreEqual("saturday".ToEnum<DayOfWeek>(), DayOfWeek.Saturday);
        }
        [TestMethod]
        public void CaseSensitiveEnumTest()
        {
            Assert.AreEqual("V1".ToEnum<CaseSensitiveEnum>(false), CaseSensitiveEnum.V1);
            Assert.AreEqual("v1".ToEnum<CaseSensitiveEnum>(false), CaseSensitiveEnum.v1);

            Assert.AreEqual("v1".ToEnum<CaseSensitiveEnum>(), CaseSensitiveEnum.V1);
            Assert.AreEqual("V1".ToEnum<CaseSensitiveEnum>(), CaseSensitiveEnum.V1);//Match first one...
        }
    }
}
