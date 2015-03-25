using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace HigLabo.Core
{
    public class QueryStringConverter
    {
        public Func<String, String> UrlEncoder = WebUtility.UrlEncode;
        public Func<String, String> UrlDecoder = WebUtility.UrlDecode;

        public Dictionary<String, String> Parse(String queryString)
        {
            var d = new Dictionary<String, String>();

            var length = queryString.Length;
            StringBuilder sb = new StringBuilder();
            String key = "";
            for (int i = 0; i < length; i++)
            {
                var c = queryString[i];
                if (c == '=')
                {
                    key = sb.ToString();
                    sb.Clear();
                }
                else if (c == '&')
                {
                    if (String.IsNullOrEmpty(key) == true)
                    {
                        d[sb.ToString()] = "";
                    }
                    else
                    {
                        d[key] = UrlDecoder(sb.ToString());
                    }
                    key = "";
                    sb.Clear();
                }
                else if (i == length - 1)
                {
                    sb.Append(c);
                    if (String.IsNullOrEmpty(key) == true)
                    {
                        d[sb.ToString()] = "";
                    }
                    else
                    {
                        d[key] = UrlDecoder(sb.ToString());
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }
            return d;
        }
        public String Write(Dictionary<String, String> values)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var key in values.Keys)
            {
                sb.Append(key);
                sb.Append("=");
                sb.Append(UrlEncoder(values[key]));
                sb.Append("&");
            }
            sb.Length = sb.Length - 1;
            return sb.ToString();
        }
    }
}
