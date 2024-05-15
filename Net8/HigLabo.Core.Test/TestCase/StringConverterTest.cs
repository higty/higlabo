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
			cv.HalfWidthNumber = true;
            cv.HalfWidthAlphabet = true;
            cv.HalfWidthKatakana = true;
            cv.FullWidthNumber = true;
            cv.FullWidthAlphabet = true;
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

        [TestMethod]
        public void StringConverter_HalfKatakana_0()
        {
            var cv = new StringConverter();
            {
                var result = cv.ToFullKatakana("｡｢｣､･ﾞﾟ");
                Assert.AreEqual("｡｢｣､･ﾞﾟ", result);
            }
        }
        [TestMethod]
        public void StringConverter_HalfKatakana_1()
        {
            var cv = new StringConverter();
            {
                var result = cv.ToFullKatakana("ｧｨｩｪｫｬｭｮｯｰ");
                Assert.AreEqual("ァィゥェォャュョッー", result);
            }
        }
        [TestMethod]
        public void StringConverter_HalfKatakana_2()
        {
            var cv = new StringConverter();
            {
                var result = cv.ToFullKatakana("ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄ");
                Assert.AreEqual("アイウエオカキクケコサシスセソタチツテト", result);
            }
        }
        [TestMethod]
        public void StringConverter_HalfKatakana_3()
        {
            var cv = new StringConverter();
            {
                var result = cv.ToFullKatakana("ﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜｦﾝ");
                Assert.AreEqual("ナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲン", result);
            }
        }
        [TestMethod]
        public void StringConverter_HalfKatakanaVoicingDiacritic()
        {
            var cv = new StringConverter();
            {
                var result = cv.ToFullKatakana("ｶﾞｷﾞｸﾞｹﾞｺﾞｻﾞｼﾞｽﾞｾﾞｿﾞﾀﾞﾁﾞﾂﾞﾃﾞﾄﾞﾊﾞﾋﾞﾌﾞﾍﾞﾎﾞ");
                Assert.AreEqual("ガギグゲゴザジズゼゾダヂヅデドバビブベボ", result);
            }
        }
        [TestMethod]
        public void StringConverter_HalfKatakanaDevoicingDiacritic()
        {
            var cv = new StringConverter();
            {
                var result = cv.ToFullKatakana("ﾊﾟﾋﾟﾌﾟﾍﾟﾎﾟ");
                Assert.AreEqual("パピプペポ", result);
            }
        }
        [TestMethod]
        public void StringConverter_HalfKatakana_Invalid()
        {
            var cv = new StringConverter();
            {
                var result = cv.ToFullKatakana("ﾅﾞﾆﾞﾇﾞﾈﾞﾉﾞﾏﾟﾐﾟﾑﾟﾒﾟﾓﾟ");
                Assert.AreEqual("ナﾞニﾞヌﾞネﾞノﾞマﾟミﾟムﾟメﾟモﾟ", result);
            }
        }
        [TestMethod]
        public void StringConverter_HalfKatakana_All()
        {
            var cv = new StringConverter();
            {
                var result = cv.ToFullKatakana("｡｢｣､･ｦｧｨｩｪｫｬｭｮｯｰｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜﾝﾞﾟ");
                Assert.AreEqual("｡｢｣､･ヲァィゥェォャュョッーアイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワンﾞﾟ", result);
            }
        }
        [TestMethod]
        public void StringConverter_HalfKatakana_All_1()
        {
            var cv = new StringConverter();
            cv.HalfWidthKatakana = true;
            {
                var result = cv.ToFullWidth("｡｢｣､･ｦｧｨｩｪｫｬｭｮｯｰｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜﾝﾞﾟ");
                Assert.AreEqual("｡｢｣､･ヲァィゥェォャュョッーアイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワンﾞﾟ", result);
            }
        }
    }
}
