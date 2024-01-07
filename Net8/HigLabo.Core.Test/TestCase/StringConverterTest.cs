using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.Core;

namespace HigLabo.Core.Test
{
    [TestClass]
    public class StringConverterTest
    {
        public enum GenericEnum
        {
            V0,
            V1,
            V2,
            V3,
            V4,
            V5,
            V6,
            V7,
            V8,
            V9,
            V10,
            V11,
        }
        [TestMethod]
        public void ToEnumBasicTest()
        {
            Assert.AreEqual("V1".ToEnum<GenericEnum>(), GenericEnum.V1);
            Assert.AreEqual("V6".ToEnum<GenericEnum>(), GenericEnum.V6);
            Assert.AreEqual("V10".ToEnum<GenericEnum>(), GenericEnum.V10);
            Assert.AreEqual("V11".ToEnum<GenericEnum>(), GenericEnum.V11);
        }
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
