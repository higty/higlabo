using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class JavaScriptStringConverter
    {
        public Boolean AddDoubleQuotes { get; set; } = false;

        public String Encode(String value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return this.AddDoubleQuotes ? "\"\"" : String.Empty;
            }
            Int32 len = value.Length;
            Boolean encodeRequired = false;
            Char c;
            for (int i = 0; i < len; i++)
            {
                c = value[i];

                if (c >= 0 && c <= 31 || c == 34 || c == 39 || c == 60 || c == 62 || c == 92)
                {
                    encodeRequired = true;
                    break;
                }
            }
            if (encodeRequired == false)
            {
                return this.AddDoubleQuotes ? "\"" + value + "\"" : value;
            }
            var sb = new StringBuilder();
            if (this.AddDoubleQuotes)
            {
                sb.Append('"');
            }

            for (int i = 0; i < len; i++)
            {
                c = value[i];
                if (c >= 0 && c <= 7 || c == 11 || c >= 14 && c <= 31 || c == 39 || c == 60 || c == 62)
                {
                    sb.AppendFormat("\\u{0:x4}", (int)c);
                }
                else
                {
                    switch ((int)c)
                    {
                        case 8: sb.Append("\\b"); break;
                        case 9: sb.Append("\\t"); break;
                        case 10: sb.Append("\\n"); break;
                        case 12: sb.Append("\\f"); break;
                        case 13: sb.Append("\\r"); break;
                        case 34: sb.Append("\\\""); break;
                        case 92: sb.Append("\\\\"); break;
                        default: sb.Append(c); break;
                    }
                }
            }
            if (this.AddDoubleQuotes)
            {
                sb.Append('"');
            }

            return sb.ToString();
        }
    }
}
