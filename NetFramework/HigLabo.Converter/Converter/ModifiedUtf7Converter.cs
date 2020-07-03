using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HigLabo.Converter
{
    public class ModifiedUtf7Converter 
    {
        private Base64Converter _Base64Converter = null;

        public ModifiedUtf7Converter(Int32 bufferSize)
        {
            _Base64Converter = new Base64Converter(bufferSize, ',');
            _Base64Converter.InsertNewline = false;
            _Base64Converter.Padding = false;
        }

        public String Encode(String text)
        {
            var encoded = new StringBuilder();
            var startIndex = -1;

            for (var index = 0; index < text.Length; index++)
            {
                var c = text[index];

                if ((0x20 <= c && c <= 0x7e))
                {
                    if (startIndex >= 0)
                    {
                        encoded.Append('&');
                        encoded.Append(_Base64Converter.Encode(text.Substring(startIndex, index - startIndex), Encoding.BigEndianUnicode));
                        encoded.Append('-');

                        startIndex = -1;
                    }
                    if (c == 0x26)
                    {
                        encoded.Append("&-");
                    }
                    else
                    {
                        encoded.Append(c);
                    }
                }
                else
                {
                    if (startIndex == -1)
                    {
                        startIndex = index;
                    }
                }
            }
            if (startIndex >= 0)
            {
                encoded.Append('&');
                encoded.Append(_Base64Converter.Encode(text.Substring(startIndex), Encoding.BigEndianUnicode));
                encoded.Append('-');
            }
            return encoded.ToString();
        }
        public String Decode(String text)
        {
            if (!text.Contains("&"))
                return text;

            var decoded = new StringBuilder();

            for (var index = 0; index < text.Length; index++)
            {
                if (text[index] != '&')
                { 
                    decoded.Append(text[index]);
                    continue;
                }

                if (text.Length <= ++index){ throw new FormatException("incorrect form"); }

                if (text[index] == '-')// &- is &
                { 
                    decoded.Append('&');
                    continue;
                }

                var nonprintable = new StringBuilder();
                Int32 startIndex = index;
                Int32 endIndex = index;

                for (; index < text.Length; index++)
                {
                    if (text[index] == '-') 
                    {
                        endIndex = index;
                        break;
                    }
                }
                var length = endIndex - startIndex;
                var padding = 4 - length % 4;
                if (padding == 4)
                {
                    padding = 0;
                }
                var bb = new Byte[length + padding];
                for (int i = 0; i < length; i++)
                {
                    bb[i] = (Byte)text[startIndex + i];
                }
                if (padding > 0)
                {
                    for (int i = length; i < length + padding; i++)
                    {
                        bb[i] = 61;// =
                    }
                }
                decoded.Append(_Base64Converter.DecodeToText(bb, Encoding.BigEndianUnicode));
            }

            return decoded.ToString();
        }
    }
}
