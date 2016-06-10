using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace HigLabo.Core
{
    public class QueryStringConverter
    {
        public Func<String, String> UrlEncoder = s => s;
        public Func<String, String> UrlDecoder = s => s;
        public StringComparer StringComparer { get; set; }

        public QueryStringConverter()
        {
            this.StringComparer = StringComparer.OrdinalIgnoreCase;
#if !Pcl
            this.UrlEncoder = WebUtility.UrlEncode;
            this.UrlDecoder = WebUtility.UrlDecode;
#endif
        }
        public Dictionary<String, String> Parse(String url)
        {
            var d = new Dictionary<String, String>(this.StringComparer);
            var queryString = url;
            var index = url.IndexOf("?");
            if (index > -1)
            {
                index = index + 1;
                if (index < url.Length)
                {
                    queryString = url.Substring(index, url.Length - index);
                }
            }
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
            if (values.Count == 0) { return ""; }

            StringBuilder sb = new StringBuilder();
            foreach (var key in values.Keys)
            {
                sb.Append(key);
                sb.Append("=");
                sb.Append(UrlEncoder(values[key]));
                sb.Append("&");
            }
            if (sb.Length > 0)
            {
                sb.Length = sb.Length - 1;
            }
            return sb.ToString();
        }
        public String Write(String url, Dictionary<String, String> values)
        {
            var q = this.Write(values);
            if (String.IsNullOrEmpty(q) == true)
            {
                return url;
            }
            return String.Format("{0}?{1}", url, q);
        }
    }
}
