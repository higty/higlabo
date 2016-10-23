using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HigLabo.Core.Test
{
    [TestClass]
    public class StringConverterTest
    {
        public enum GenericEnum
        {
            V0,
            V1,
            V2,
            V3,
            V4,
            V5,
            V6,
            V7,
            V8,
            V9,
            V10,
            V11,
        }
        [TestMethod]
        public void ToEnumBasicTest()
        {
            Assert.AreEqual("V1".ToEnum(typeof(GenericEnum)), GenericEnum.V1);
            Assert.AreEqual("V6".ToEnum(typeof(GenericEnum)), GenericEnum.V6);
            Assert.AreEqual("V10".ToEnum(typeof(GenericEnum)), GenericEnum.V10);
            Assert.AreEqual("V11".ToEnum(typeof(GenericEnum)), GenericEnum.V11);
        }
    }
}
