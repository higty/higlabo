using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;
using HigLabo.Converter;

namespace HigLabo.Mime.Test
{
    /// <summary>
    /// Convert Tool Site is https://hogehoge.tk/tool/
    /// </summary>
    [TestClass]
    public class Base64ConverterTest
    {
        [TestMethod]
        public void Base64Converter_Encode_NotInsertNewline()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var bs = new Base64Converter(2000);
            bs.InsertNewline = false;
            var bb = bs.Encode(Encoding.GetEncoding(932).GetBytes("<div style='font-size:20px;'>This is a text/html body text.</div>"));
            var encodedText = Encoding.UTF8.GetString(bb);
            Assert.AreEqual("PGRpdiBzdHlsZT0nZm9udC1zaXplOjIwcHg7Jz5UaGlzIGlzIGEgdGV4dC9odG1sIGJvZHkgdGV4dC48L2Rpdj4=", encodedText);
        }
        [TestMethod]
        public void Base64Converter_Encode_InsertNewline()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var bs = new Base64Converter(2000);
            bs.InsertNewline = true;
            var bb = bs.Encode(Encoding.GetEncoding(932).GetBytes("<div style='font-size:20px;'>This is a text/html body text.</div>"));
            var encodedText = Encoding.UTF8.GetString(bb);
            Assert.AreEqual("PGRpdiBzdHlsZT0nZm9udC1zaXplOjIwcHg7Jz5UaGlzIGlzIGEgdGV4dC9odG1sIGJvZHkg\r\ndGV4dC48L2Rpdj4=", encodedText);
        }
        [TestMethod]
        public void Base64Converter_Encode_InsertNewline_löschen()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var bs = new Base64Converter(2000);
            bs.InsertNewline = true;
            var bb = bs.Encode(Encoding.UTF8.GetBytes("<div style='font-size:20px;'>This is a text/html body text.Test word is löschen</div>"));
            var encodedText = Encoding.UTF8.GetString(bb);
            Assert.AreEqual("PGRpdiBzdHlsZT0nZm9udC1zaXplOjIwcHg7Jz5UaGlzIGlzIGEgdGV4dC9odG1sIGJvZHkg" + Environment.NewLine
                + "dGV4dC5UZXN0IHdvcmQgaXMgbMO2c2NoZW48L2Rpdj4=", encodedText);
        }
    }
}
