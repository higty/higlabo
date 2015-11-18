using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HigLabo.Core.Test
{
    [TestClass]
    public class EnumExtensionsTest
    {
        public enum BaseIsNotZeroEnum : byte
        {
            V2 = 2,
            V3,
            V4,
            V5,
            V6,
        }
        public enum ByteEnum : byte
        {
            V0 = 0,
            V2 = 2,
            V4 = 4,
        }
        public enum LongEnum : long
        {
            V0 = 0,
            V2 = 2,
            V1620100 = 1620100,
            V23372036854775807 = 23372036854775807,
        }
        [FlagsAttribute]
        enum FlagsEnum
        {
            None = 0x00, // 0000 0000
            One = 0x01, // 0000 0001
            Two = 0x02, // 0000 0010 
            Three = 0x04, // 0000 0100
            Four = 0x08, // 0000 1000
            All = 0x0F // 0000 1111
        }
        [TestMethod]
        public void BasicEnumTest()
        {
            Assert.AreEqual(DayOfWeek.Friday.ToStringFromEnum(), "Friday");
            Assert.AreEqual(DayOfWeek.Wednesday.ToStringFromEnum(), "Wednesday");
        }
        [TestMethod]
        public void BaseIsNotZeroEnumTest()
        {
            Assert.AreEqual(BaseIsNotZeroEnum.V2.ToStringFromEnum(), "V2");
            Assert.AreEqual(BaseIsNotZeroEnum.V3.ToStringFromEnum(), "V3");
            Assert.AreEqual(BaseIsNotZeroEnum.V4.ToStringFromEnum(), "V4");
        }
        [TestMethod]
        public void ByteEnumTest()
        {
            Assert.AreEqual(ByteEnum.V0.ToStringFromEnum(), "V0");
            Assert.AreEqual(ByteEnum.V2.ToStringFromEnum(), "V2");
            Assert.AreEqual(ByteEnum.V4.ToStringFromEnum(), "V4");
        }
        [TestMethod]
        public void LongEnumTest()
        {
            Assert.AreEqual(LongEnum.V0.ToStringFromEnum(), "V0");
            Assert.AreEqual(LongEnum.V2.ToStringFromEnum(), "V2");
            Assert.AreEqual(LongEnum.V1620100.ToStringFromEnum(), "V1620100");
            Assert.AreEqual(LongEnum.V23372036854775807.ToStringFromEnum(), "V23372036854775807");
        }
        [TestMethod]
        public void FlagEnumTest()
        {
            Assert.AreEqual(FlagsEnum.One.ToStringFromEnum(), "One");
            Assert.AreEqual((FlagsEnum.One | FlagsEnum.Two).ToStringFromEnum(), "One,Two");
            Assert.AreEqual(FlagsEnum.Three.ToStringFromEnum(), "Three");
            Assert.AreEqual(FlagsEnum.Four.ToStringFromEnum(), "Four");
        }
    }
}
