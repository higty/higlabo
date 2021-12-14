using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;

namespace HigLabo.Mime.Test
{
    [TestClass]
    public class MimeHeaderTest
    {
        private MimeParser Parser10 = new MimeParser(Encoding.UTF8, 10);
        private MimeParser Parser256 = new MimeParser(Encoding.UTF8, 256);
        [TestMethod]
        public void MimeHeader_Basic1()
        {
            String src = "Date: Wed, 8 Jan 2014 10:44:49 +0900\r\n";
            foreach (var header in CreateHeaders(Encoding.UTF8.GetBytes(src)))
            {
                Assert.AreEqual("Date", header.Key);
                Assert.AreEqual("Wed, 8 Jan 2014 10:44:49 +0900", header.Value);
                Assert.AreEqual("Wed, 8 Jan 2014 10:44:49 +0900\r\n", header.RawValue);
                Assert.AreEqual("Date: Wed, 8 Jan 2014 10:44:49 +0900\r\n", header.GetRawText());
            }
        }
        [TestMethod]
        public void MimeHeader_Basic2()
        {
            String src = "Received: from bay0-omc4-s6.bay0.hotmail.com ([65.54.190.208]);\r\n\t Tue, 7 Jan 2014 17:44:50 -0800\r\n";

            foreach (var header in CreateHeaders(Encoding.UTF8.GetBytes(src)))
            {
                Assert.AreEqual("Received", header.Key);
                Assert.AreEqual("from bay0-omc4-s6.bay0.hotmail.com ([65.54.190.208]); Tue, 7 Jan 2014 17:44:50 -0800", header.Value);
                Assert.AreEqual("from bay0-omc4-s6.bay0.hotmail.com ([65.54.190.208]);\r\n\t Tue, 7 Jan 2014 17:44:50 -0800\r\n", header.RawValue);
                Assert.AreEqual(src, header.GetRawText());
            }
        }
        [TestMethod]
        public void MimeHeader_Rfc2047_Base64()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            String src = "From: =?ISO-2022-JP?B?GyRCQXc/LkBoGyhC?= <xxxxx@hotmail.com>";

            foreach (var header in CreateHeaders(Encoding.UTF8.GetBytes(src)))
            {
                Assert.AreEqual("From", header.Key);
                Assert.AreEqual("送信先 <xxxxx@hotmail.com>", header.Value);
                Assert.AreEqual("=?ISO-2022-JP?B?GyRCQXc/LkBoGyhC?= <xxxxx@hotmail.com>", header.RawValue);
                Assert.AreEqual(src, header.GetRawText());
            }
        }
        [TestMethod]
        public void MimeHeader_Rfc2047_QuotedPrintable()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            String src = "Subject: =?iso-2022-jp?Q?=1B$B%F%9%H=1B(Bab=1B$B4A;z=1B(B?= TestQuotedPrintable";

            foreach (var header in CreateHeaders(Encoding.UTF8.GetBytes(src)))
            {
                Assert.AreEqual("Subject", header.Key);
                Assert.AreEqual("テストab漢字 TestQuotedPrintable", header.Value);
                Assert.AreEqual("=?iso-2022-jp?Q?=1B$B%F%9%H=1B(Bab=1B$B4A;z=1B(B?= TestQuotedPrintable", header.RawValue);
                Assert.AreEqual(src, header.GetRawText());
            }
        }
        [TestMethod]
        public void MimeHeader_ContentType_Name()
        {
            var parser = Parser10;
            ContentType contentType = null;

            contentType = new ContentType();
            contentType.RawValue = "Image/png;\r\n"
                + "\tName=\"MyFile;01.pdf\";";
            parser.ParseContentType(contentType);
            Assert.AreEqual("MyFile;01.pdf", contentType.Name);

            contentType = new ContentType();
            contentType.RawValue = "Image/png;\r\n"
                + "\tName=MyFile\"05.pdf;";
            parser.ParseContentType(contentType);
            Assert.AreEqual("MyFile\"05.pdf", contentType.Name);

            contentType = new ContentType();
            contentType.RawValue = "Image/png;\r\n"
                + "\tName=\"MyFile\"06.pdf\";";
            parser.ParseContentType(contentType);
            Assert.AreEqual("MyFile\"06.pdf", contentType.Name);

            //Maybe...
            contentType = new ContentType();
            contentType.RawValue = "Image/png;\r\n"
                + "\tName=\"MyFile\"07.pdf;\r\n" 
                + "\tcharset=\"UTF-8\"";
            parser.ParseContentType(contentType);
            Assert.AreEqual("\"MyFile\"07.pdf;", contentType.Name);

        }

        private IEnumerable<MimeHeader> CreateHeaders(Byte[] rawText)
        {
            yield return Parser10.ParseHeader(rawText);
            yield return Parser256.ParseHeader(rawText);
        }
    }
}
