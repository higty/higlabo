using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Core;

namespace HigLabo.Bot.Line
{
    internal static class StringBuilderExtensions
    {
        public static StringBuilder AppendJsonEncoded(this StringBuilder stringBuilder, String text)
        {
            return stringBuilder.Append(JavaScriptStringEncode(text, false));
        }
        private static string JavaScriptStringEncode(string value, bool addDoubleQuotes)
        {
            var cv = new JavaScriptStringConverter();
            cv.AddDoubleQuotes = addDoubleQuotes;
            return cv.Encode(value);
        }
    }
}
