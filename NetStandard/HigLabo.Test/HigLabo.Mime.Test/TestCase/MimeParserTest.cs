using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;
using HigLabo.Core;

namespace HigLabo.Mime.Test
{
    [TestClass]
    public class MimeParserTest
    {
        private static Boolean _RegisterProviderExecuted = false;
        public static readonly String BodyText = @"祇園精舎の鐘の声
諸行無常の響きあり
沙羅双樹の花の色
盛者必衰の理をあらわす
";

        private static void RegisterProvider()
        {
            if (_RegisterProviderExecuted) { return; }
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _RegisterProviderExecuted = true;
        }
        [TestMethod]
        public void MimeParser_InvalidCharset()
        {
            RegisterProvider();

            var mg = GetMailMessage(Environment.CurrentDirectory + "\\TestData\\Mail_InvalidCharset.txt");
            String expectedText = "This is a text/plain body text.";

            var ct = mg.Contents[1];
            Assert.AreEqual(expectedText, ct.Contents[0].BodyText);
            Assert.AreEqual(expectedText, ct.Contents[1].BodyText);
            Assert.AreEqual(expectedText, ct.Contents[2].BodyText);
            Assert.AreEqual("<div style='font-size:20px;'>This is a text/html body text.</div>", ct.Contents[3].BodyText);
        }
        [TestMethod]
        public void MimeParser_BodyText_Content()
        {
            RegisterProvider();

            var mg = GetMailMessage(Environment.CurrentDirectory + "\\TestData\\Mail_BodyText_Content.txt");

            Assert.AreEqual(BodyText, mg.BodyText);
            Assert.AreEqual(BodyText, mg.Contents[0].BodyText);
            Assert.AreEqual("This is a text/plain body text.", mg.Contents[1].BodyText);
        }
        [TestMethod]
        public void Mail_Shift_jis_8bit()
        {
            RegisterProvider();

            var mg = GetMailMessage(Environment.CurrentDirectory + "\\TestData\\Mail_Shift_jis_8bit.txt");
            var body = @"This is a test of Shift_JIS 8bit mail.
Is test result green?
";
            Assert.AreEqual(body, mg.BodyText);
        }
        [TestMethod]
        public void Mail_Mail_BodyText_BeforeBoundary()
        {
            RegisterProvider();

            var mg = GetMailMessage(Environment.CurrentDirectory + "\\TestData\\Mail_BodyText_BeforeBoundary.txt");
            Assert.AreEqual(BodyText, mg.BodyText);
        }
        [TestMethod]
        public void Mail_Rfc822()
        {
            RegisterProvider();

            var mg = GetMailMessage(Environment.CurrentDirectory + "\\TestData\\Mail_Rfc822.txt");

            Assert.AreEqual(mg.AttachmentFiles.Count(), 1);

        }
        [TestMethod]
        public void Mail_CodePlex_21851()
        {
            var mailText = File.ReadAllText(Environment.CurrentDirectory + "\\TestData\\Mail_CodePlex_21851.txt");
            MimeParser parser = new MimeParser();
            var mg = parser.ToMailMessage(mailText.UnifyLineFeed());

            Assert.AreEqual(mg.AttachmentFiles.Count(), 1);
            var messages = mg.TransferedMailMessages.ToList();
            Assert.AreEqual(messages.Count, 1);
            var tmg = messages[0];
            Assert.AreEqual(tmg.Subject, "Inner email subject");
        }
        [TestMethod]
        public void Mail_InvalidFileName()
        {
            RegisterProvider();

            var mg = GetMailMessage(Environment.CurrentDirectory + "\\TestData\\Mail_InvalidFileName.txt");
            Assert.AreEqual("\"Отгрузка на Мыс Астафьева в Мае 2018 ТМСШ 11% 1553 (ЕВРАЗ).xlsx\""
                , mg.Contents[1].FileName);

        }

        private MailMessage GetMailMessage(String filePath)
        {
            MimeParser parser = new MimeParser();

            using (var str = new FileStream(filePath, FileMode.Open))
            {
                return parser.ToMailMessage(str);
            }
        }
    }
}
