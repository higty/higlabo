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
    public class StringConverterTest
    {
        [TestMethod]
        public void StringConverter_Basic()
        {
            var cv = new StringConverter();
            cv.FullWidthNumber = true;
            cv.HalfWidthNumber = true;
            cv.FullWidthAlphabet = true;
            cv.HalfWidthAlphabet = true;
            {
                var result = cv.ToHalfWidth("ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ");
                Assert.AreEqual("ABCDEFGHIJKLMNOPQRSTUVWXYZ", result);
            }
            {
                var result = cv.ToHalfWidth("ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚ");
                Assert.AreEqual("abcdefghijklmnopqrstuvwxyz", result);
            }
            {
                var result = cv.ToFullWidth("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                Assert.AreEqual("ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ", result);
            }
            {
                var result = cv.ToFullWidth("abcdefghijklmnopqrstuvwxyz");
                Assert.AreEqual("ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚ", result);
            }

            {
                var result = cv.ToHalfWidth("０１２３４５６７８９");
                Assert.AreEqual("0123456789", result);
            }
            {
                var result = cv.ToFullWidth("0123456789");
                Assert.AreEqual("０１２３４５６７８９", result);
            }
        }
    }
}
