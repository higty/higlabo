using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Converter
{
    public class Rfc2231Converter
    {
        public String Decode(String text)
        {
            Int32 index0 = -1;
            Int32 index1 = -1;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\'')
                {
                    if (index0 == -1)
                    {
                        index0 = i;
                    }
                    else
                    {
                        index1 = i;
                        break;
                    }
                }
            }
            if (index0 > -1 && index1 > -1)
            {
                var encoding = EncodingDictionary.Current.GetEncoding(text.Substring(0, index0));
                return Decode(text.Substring(index1 + 1), encoding);
            }
            return text;
        }
        public String Decode(String text, Encoding encoding)
        {
            Int32 currentIndex = 0;
            Byte[] bb = new Byte[text.Length];
            Int32 ByteArrayIndex = 0;
            Int32? Hex = null;

            while (true)
            {
                //%FF形式かどうかチェック
                if (currentIndex <= text.Length - 3 &&
                    text[currentIndex] == '%')
                {
                    Hex = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        var c1 = (Byte)text[currentIndex + 1 + i];

                        if (c1 >= 48 && c1 <= 57)
                        {
                            Hex += (c1 - 48);
                        }
                        if (c1 >= 65 && c1 <= 70)
                        {
                            Hex += (c1 - 65 + 10);
                        }
                        if (c1 >= 97 && c1 <= 102)
                        {
                            Hex += (c1 - 97 + 10);
                        }
                        if (i == 0)
                        {
                            Hex = Hex * 16;
                        }
                    }
                }
                else
                {
                    Hex = null;
                }

                if (Hex.HasValue == true)
                {
                    bb[ByteArrayIndex] = (Byte)Hex.Value;
                    currentIndex += 3;
                }
                else
                {
                    bb[ByteArrayIndex] = (Byte)text[currentIndex];
                    currentIndex += 1;
                }
                ByteArrayIndex += 1;
                if (currentIndex >= text.Length) { break; }
            }
            //バイト配列を文字列に変換
            Byte[] bb2 = new Byte[ByteArrayIndex];
            Array.Copy(bb, 0, bb2, 0, ByteArrayIndex);
            return encoding.GetString(bb2);
        }
    }
}
