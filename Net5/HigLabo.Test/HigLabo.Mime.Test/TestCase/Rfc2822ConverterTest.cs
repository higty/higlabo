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
    public class Rfc2822ConverterTest
    {
        [TestMethod]
        public void Rfc2822Converter_Basic1()
        {
            var d = new Rfc2822Converter().Parse("Tue, 8 Oct 2013 07:37:49 +0430");

            Assert.AreEqual(d.Year, 2013);
            Assert.AreEqual(d.Month, 10);
            Assert.AreEqual(d.Day, 8);
            Assert.AreEqual(d.Hour, 7);
            Assert.AreEqual(d.Minute, 37);
            Assert.AreEqual(d.Second, 49);
            Assert.AreEqual(d.Offset.Hours, 4);
            Assert.AreEqual(d.Offset.Minutes, 30);
        }
        [TestMethod]
        public void Rfc2822Converter_Basic2()
        {
            var d = new Rfc2822Converter().Parse("Tue, 8 Oct 2013 07:37:49 +0900 (JST)");

            Assert.AreEqual(d.Year, 2013);
            Assert.AreEqual(d.Month, 10);
            Assert.AreEqual(d.Day, 8);
            Assert.AreEqual(d.Hour, 7);
            Assert.AreEqual(d.Minute, 37);
            Assert.AreEqual(d.Second, 49);
            Assert.AreEqual(d.Offset.Hours, 9);
            Assert.AreEqual(d.Offset.Minutes, 0);
        }
        [TestMethod]
        public void Rfc2822Converter_Basic3()
        {
            var d = new Rfc2822Converter().Parse("Tue, 8 Oct 2013 07:37:49 (JST)");

            Assert.AreEqual(d.Year, 2013);
            Assert.AreEqual(d.Month, 10);
            Assert.AreEqual(d.Day, 8);
            Assert.AreEqual(d.Hour, 7);
            Assert.AreEqual(d.Minute, 37);
            Assert.AreEqual(d.Second, 49);
            Assert.AreEqual(d.Offset.Hours, 9);
        }
    }
}
