using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public static class CharExtensions
    {
        public static Boolean IsLower(this Char c)
        {
            return Char.IsLower(c);
        }
        public static Boolean IsUpper(this Char c)
        {
            return Char.IsUpper(c);
        }
        public static Boolean IsLatin(this Char c)
        {
            return IsUpperLatin(c) || IsLowerLatin(c);
        }
        public static Boolean IsUpperLatin(this Char c)
        {
            return ('A' <= c && c <= 'Z') || ('Ａ' <= c && c <= 'Ｚ');
        }
        public static Boolean IsLowerLatin(this Char c)
        {
            return ('a' <= c && c <= 'z') || ('ａ' <= c && c <= 'ｚ');
        }
        public static Boolean IsNumber(this Char c)
        {
            return Char.IsNumber(c);
        }
        public static Boolean IsLetter(this Char c)
        {
            return Char.IsLetter(c);
        }
        public static Boolean IsHiragana(this Char c)
        {
            //「ぁ」～「より」までと、「ー」「ダブルハイフン」をひらがなとする
            return ('\u3041' <= c && c <= '\u309F') || c == '\u30FC' || c == '\u30A0';
        }
        public static Boolean IsFullwidthKatakana(this Char c)
        {
            //「ダブルハイフン」から「コト」までと、カタカナフリガナ拡張と、
            //濁点と半濁点を全角カタカナとする
            //中点と長音記号も含む
            return ('\u30A0' <= c && c <= '\u30FF') ||
                ('\u31F0' <= c && c <= '\u31FF') ||
                ('\u3099' <= c && c <= '\u309C');
        }
        public static Boolean IsHalfwidthKatakana(this Char c)
        {
            //「･」から「ﾟ」までを半角カタカナとする
            return '\uFF65' <= c && c <= '\uFF9F';
        }
        public static Boolean IsKatakana(this Char c)
        {
            //「ダブルハイフン」から「コト」までと、カタカナフリガナ拡張と、
            //濁点と半濁点と、半角カタカナをカタカナとする
            //中点と長音記号も含む
            return ('\u30A0' <= c && c <= '\u30FF') ||
                ('\u31F0' <= c && c <= '\u31FF') ||
                ('\u3099' <= c && c <= '\u309C') ||
                ('\uFF65' <= c && c <= '\uFF9F');
        }
        public static Boolean IsKatakanaWithout中黒(this Char c)
        {
            //「ダブルハイフン」から「コト」までと、カタカナフリガナ拡張と、
            //濁点と半濁点と、半角カタカナをカタカナとする
            //長音記号も含む
            //中点（中黒）は除く
            return ('\u30A0' <= c && c <= '\u30FF')
                || ('\u31F0' <= c && c <= '\u31FF')
                || ('\u3099' <= c && c <= '\u309C')
                || ('\uFF66' <= c && c <= '\uFF9F');
        }
        public static Boolean IsKanji(this Char c)
        {
            return ('\u4E00' <= c && c <= '\u9FCF') ||
                ('\uF900' <= c && c <= '\uFAFF') ||
                ('\u3400' <= c && c <= '\u4DBF');
        }
        public static Boolean IsFullWidthKatakana(this Char c)
        {
            return ('\u30A0' <= c && c <= '\u30FF')
                || ('\u31F0' <= c && c <= '\u31FF')
                || ('\u3099' <= c && c <= '\u309C');
        }
        public static Boolean IsHalfWidthKatakana(this Char c)
        {
            return '\uFF66' <= c && c <= '\uFF9F';
        }
    }
}
