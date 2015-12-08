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
            Assert.AreEqual("Friday", DayOfWeek.Friday.ToStringFromEnum());
            Assert.AreEqual("Wednesday", DayOfWeek.Wednesday.ToStringFromEnum());
            Assert.AreEqual("Saturday", DayOfWeek.Saturday.ToStringFromEnum());
            Assert.AreEqual("Friday", ((DayOfWeek)(5)).ToStringFromEnum());
            Assert.AreEqual("Saturday", ((DayOfWeek)(6)).ToStringFromEnum());
        }
        [TestMethod]
        public void BaseIsNotZeroEnumTest()
        {
            Assert.AreEqual("V2", BaseIsNotZeroEnum.V2.ToStringFromEnum());
            Assert.AreEqual("V3", BaseIsNotZeroEnum.V3.ToStringFromEnum());
            Assert.AreEqual("V4", BaseIsNotZeroEnum.V4.ToStringFromEnum());
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyValueTest()
        {
            String s = "";
            s = ((DayOfWeek)(-1)).ToStringFromEnum();
            s = ((DayOfWeek)(7)).ToStringFromEnum();
            s = ((HttpStatusCode)(3)).ToStringFromEnum();
        }
        [TestMethod]
        public void ByteEnumTest()
        {
            Assert.AreEqual("V0", ByteEnum.V0.ToStringFromEnum());
            Assert.AreEqual("V2", ByteEnum.V2.ToStringFromEnum());
            Assert.AreEqual("V4", ByteEnum.V4.ToStringFromEnum());
        }
        [TestMethod]
        public void LongEnumTest()
        {
            Assert.AreEqual("V0", LongEnum.V0.ToStringFromEnum());
            Assert.AreEqual("V2", LongEnum.V2.ToStringFromEnum());
            Assert.AreEqual("V1620100", LongEnum.V1620100.ToStringFromEnum());
            Assert.AreEqual("V23372036854775807", LongEnum.V23372036854775807.ToStringFromEnum());
        }
        [TestMethod]
        public void FlagEnumTest()
        {
            Assert.AreEqual("One", FlagsEnum.One.ToStringFromEnum());
            Assert.AreEqual("One,Two", (FlagsEnum.One | FlagsEnum.Two).ToStringFromEnum());
            Assert.AreEqual("Three", FlagsEnum.Three.ToStringFromEnum());
            Assert.AreEqual("Four", FlagsEnum.Four.ToStringFromEnum());
        }

        [TestMethod]
        public void ManyValueEnumTest()
        {
            Assert.AreEqual("TemperatureC", DataTypeName.TemperatureC.ToStringFromEnum());
            Assert.AreEqual("Velocity", DataTypeName.Velocity.ToStringFromEnum());
            Assert.AreEqual("Gps", DataTypeName.Gps.ToStringFromEnum());
        }
        [TestMethod]
        public void HttpStatusCodeEnumTest()
        {
            Assert.AreEqual("Continue", HttpStatusCode.Continue.ToStringFromEnum());
            Assert.AreEqual("BadRequest", HttpStatusCode.BadRequest.ToStringFromEnum());
            Assert.AreEqual("Forbidden", HttpStatusCode.Forbidden.ToStringFromEnum());
            Assert.AreEqual("InternalServerError", HttpStatusCode.InternalServerError.ToStringFromEnum());
            Assert.AreEqual("OK", ((HttpStatusCode)(200)).ToStringFromEnum());
        }
    }
    public enum DataTypeName
    {
        Unknown,
        TemperatureC,
        TemperatureF,
        Humidity,
        WaterVolume,
        WindSpeed,
        WindBearing,
        Velocity,
        Luminance,
        Illuminance,
        Decibel,
        Weight,
        Pressure,
        Gps,
    }

    public enum HttpStatusCode
    {
        Continue = 100,
        SwitchingProtocols = 101,
        OK = 200,
        Created = 201,
        Accepted = 202,
        NonAuthoritativeInformation = 203,
        NoContent = 204,
        ResetContent = 205,
        PartialContent = 206,
        MultipleChoices = 300,
        Ambiguous = 300,
        MovedPermanently = 301,
        Moved = 301,
        Found = 302,
        Redirect = 302,
        SeeOther = 303,
        RedirectMethod = 303,
        NotModified = 304,
        UseProxy = 305,
        Unused = 306,
        TemporaryRedirect = 307,
        RedirectKeepVerb = 307,
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        NotAcceptable = 406,
        ProxyAuthenticationRequired = 407,
        RequestTimeout = 408,
        Conflict = 409,
        Gone = 410,
        LengthRequired = 411,
        PreconditionFailed = 412,
        RequestEntityTooLarge = 413,
        RequestUriTooLong = 414,
        UnsupportedMediaType = 415,
        RequestedRangeNotSatisfiable = 416,
        ExpectationFailed = 417,
        UpgradeRequired = 426,
        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
        ServiceUnavailable = 503,
        GatewayTimeout = 504,
        HttpVersionNotSupported = 505
    }
}
