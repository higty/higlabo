using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;
using HigLabo.Converter;

namespace HigLabo.Mime.Test
{
    [TestClass]
    public class Base64ConverterTest
    {
        public static readonly String BodyText = @"basic 4F68A202-27A0-C639-D55E-39D556158DC2:4F68A202-27A0-C639-D55E-39D556158DC2";
        [TestMethod]
        public void Base64Converter_Encode()
        {
            var cv = new Base64Converter(2000);
            cv.InsertNewline = false;

            var encodedText = cv.Encode(BodyText, Encoding.UTF8);
            var expectedText = Convert.ToBase64String(Encoding.UTF8.GetBytes(BodyText));
            Assert.AreEqual(expectedText, encodedText);
        }
    }
}
