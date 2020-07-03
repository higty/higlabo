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
    public class QuotedPrintableConverterTest
    {
        public static readonly String BodyText = @"祇園精舎の鐘の声
諸行無常の響きあり
沙羅双樹の花の色
盛者必衰の理をあらわす
";
        [TestMethod]
        public void QuotedPrintableConverter_Encode_InsertNewline()
        {
            var qc = new QuotedPrintableConverter(2000, QuotedPrintableConvertMode.Default);
            qc.InsertNewline = true;

            var bb = qc.Encode(Encoding.GetEncoding("Iso-2022-JP").GetBytes(BodyText));
            var encodedText = Encoding.UTF8.GetString(bb);
            Assert.AreEqual("=1B$B5@1`@:<K$N>b$N@<=1B(B=0D=0A=1B$B=3Dt9TL5>o$N6A$-$\"$j=1B(B=0D=0A=1B$B:=" + Environment.NewLine
                + ";MeAP<y$N2V$N?'=1B(B=0D=0A=1B$B@9<TI,?j$NM}$r$\"$i$o$9=1B(B=0D=0A", encodedText);
        }
        [TestMethod]
        public void QuotedPrintableConverter_Decode()
        {
            var qc = new QuotedPrintableConverter(2000, QuotedPrintableConvertMode.Default);
            qc.InsertNewline = true;
            var text ="=1B$B5@1`@:<K$N>b$N@<=1B(B=0D=0A=1B$B=3Dt9TL5>o$N6A$-$\"$j=1B(B=0D=0A=1B$B:=" + Environment.NewLine
                + ";MeAP<y$N2V$N?'=1B(B=0D=0A=1B$B@9<TI,?j$NM}$r$\"$i$o$9=1B(B=0D=0A";
            var bb = qc.Decode(Encoding.UTF8.GetBytes(text));
            var decodedText = Encoding.GetEncoding("Iso-2022-JP").GetString(bb);
            Assert.AreEqual(BodyText, decodedText);
        }
    }
}
