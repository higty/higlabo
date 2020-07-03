using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.Core;

namespace HigLabo.Converter.Test
{
    [TestClass]
    public class QueryStringConverterTest
    {
        [TestMethod]
        public void QueryStringConverter_StartTimeWithTimeZone()
        {
            QueryStringConverter cv = new QueryStringConverter();

            var d = cv.Parse("?StartTime=2016-06-09+10%3A58%3A14+%2B09%3A00");
            Assert.AreEqual("2016-06-09 10:58:14 +09:00", d["StartTime"]);

        }
    }
}
