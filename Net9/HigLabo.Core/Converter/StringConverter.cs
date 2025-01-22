using System;
using System.Text.RegularExpressions;

namespace HigLabo.Core;

public class StringConverter
{
    public static class RegexList
    {
        public static Regex HalfKanaWithVoicingDiacritic = new Regex(@"[ｶ-ﾄ]ﾞ|[ﾊ-ﾎ]ﾞ", RegexOptions.Compiled);
        public static Regex HalfKanaWithDevoicingDiacritic = new Regex(@"[ﾊ-ﾎ]ﾟ", RegexOptions.Compiled);
        public static Regex HalfKana = new Regex(@"[ｦ-ﾝ]", RegexOptions.Compiled);
    }
    private const Int32 FullHalfDifference = 65248;
    public Boolean HalfWidthNumber { get; set; }
    public Boolean HalfWidthAlphabet { get; set; }
    public Boolean HalfWidthKatakana { get; set; }
    public Boolean FullWidthNumber { get; set; }
    public Boolean FullWidthAlphabet { get; set; }

    public String ToFullWidth(String value)
    {
        var cc = new Char[value.Length];

        for (Int32 i = 0; i < value.Length; i++)
        {
            var c = value[i];

            if ((this.HalfWidthNumber && 48 <= c && c <= 58) ||
                (this.HalfWidthAlphabet && 65 <= c && c <= 90) ||
                (this.HalfWidthAlphabet && 97 <= c && c <= 122))
            {
                cc[i] = (char)(value[i] + FullHalfDifference);
            }
            else
            {
                cc[i] = value[i];
            }
        }
        if (this.HalfWidthKatakana)
        {
            return ToFullKatakana(new string(cc));
        }
        return new string(cc);
    }
    public String ToHalfWidth(String value)
    {
        var cc = new Char[value.Length];

        for (Int32 i = 0; i < value.Length; i++)
        {
            var c = value[i];
            if ((this.FullWidthNumber && 65296 <= c && c <= 65306) ||
                (this.FullWidthAlphabet && 65313 <= c && c <= 65338) ||
                (this.FullWidthAlphabet && 65345 <= c && c <= 65370)) 
            {
                cc[i] = (char)(value[i] - FullHalfDifference);
            }
            else
            {
                cc[i] = value[i];
            }
        }
        return new String(cc);
    }
    public string ToFullKatakana(string value)
    {
        //濁点ありのカタカナ（カからホまで）
        var output = value;
        output = RegexList.HalfKanaWithVoicingDiacritic.Replace(output, match =>
        {
            var c = match.Value[0];
            //カからトまで
            if (c >= 65398 && c <= 65412)
            {
                if (c < 65410)
                {
                    return new string(new char[] { (Char)(12460 + (c - 65398) * 2) });
                }
                else
                {
                    //小さいツの分、1つずらす
                    return new string(new char[] { (Char)(12460 + (c - 65398) * 2 + 1) });
                }
            }
            //ハからホまで
            if (c >= 65418 && c <= 65422)
            {
                return new string(new char[] { (Char)(12495 + (c - 65418) * 3 + 1) });
            }
            return match.Value;
        });
        //半濁点ありのカタカナ（パピプペポ）
        output = RegexList.HalfKanaWithDevoicingDiacritic.Replace(output, match =>
        {
            var c = match.Value[0];
            //ハからホまで
            if (c >= 65418 && c <= 65422)
            {
                return new string(new char[] { (Char)(12495 + (c - 65418) * 3 + 2) });
            }
            return match.Value;
        });
        //半角カタカナ
        output = RegexList.HalfKana.Replace(output, match =>
        {
            var c = match.Value[0];
            //ヤ
            if (c == 65428) { return new string(new char[] { (char)12516 }); }
            //ユ
            if (c == 65429) { return new string(new char[] { (char)12518 }); }
            //ヨ
            if (c == 65430) { return new string(new char[] { (char)12520 }); }
            //ワ
            if (c == 65436) { return new string(new char[] { (char)12527 }); }
            //ヲ
            if (c == 65382) { return new string(new char[] { (char)12530 }); }
            //ン
            if (c == 65437) { return new string(new char[] { (char)12531 }); }
            //ッ
            if (c == 65391) { return new string(new char[] { (char)12483 }); }
            //ッ
            if (c == 65392) { return new string(new char[] { (char)12540 }); }

            //ァからォまで
            if (c >= 65383 && c <= 65387)
            {
                return new string(new char[] { (Char)(12449 + (c - 65383) * 2) });
            }
            //ャからョまで
            if (c >= 65388 && c <= 65390)
            {
                return new string(new char[] { (Char)(12515 + (c - 65388) * 2) });
            }
            //アからオまで
            if (c >= 65393 && c <= 65397)
            {
                return new string(new char[] { (Char)(12450 + (c - 65393) * 2) });
            }
            //カからチまで
            if (c >= 65398 && c <= 65412)
            {
                var cc = new Char[1];
                if (c < 65410)
                {
                    return new string(new char[] { (Char)(12459 + (c - 65398) * 2) });
                }
                else
                {
                    //小さいツの分、1つずらす
                    return new string(new char[] { (Char)(12459 + (c - 65398) * 2 + 1) });
                }
            }
            //ナからノまで
            if (c >= 65413 && c <= 65417)
            {
                return new string(new char[] { (Char)(12490 + (c - 65413)) });
            }
            //ハからホまで
            if (c >= 65418 && c <= 65422)
            {
                return new string(new char[] { (Char)(12495 + (c - 65418) * 3) });
            }
            //マからモまで
            if (c >= 65423 && c <= 65427)
            {
                return new string(new char[] { (Char)(12510 + (c - 65423)) });
            }
            //ラからロまで
            if (c >= 65431 && c <= 65435)
            {
                var cc = new Char[1];
                cc[0] = (Char)(12521 + (c - 65431));
                return new string(cc);
            }
            return match.Value;
        });
        return output;
    }
}
