using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HigLabo.Converter.Test
{
    [TestClass]
    public class Rfc2822ConverterTest
    {
        [TestMethod]
        public void Rfc2822Converter_Date()
        {
            var cv = new Rfc2822Converter();

            var dateText = "Thu, 9 Aug 2018 16:33:07 +0900";
            var date = cv.Parse(dateText);

            Assert.AreEqual(new DateTimeOffset(2018, 8, 9, 16, 33, 07, TimeSpan.FromHours(9)), date);
        }
    }
}
