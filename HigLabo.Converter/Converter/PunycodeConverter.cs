using System;
using System.Collections.Generic;
using System.Globalization;

namespace HigLabo.Core
{
    public class PunycodeConverter
    {
        public String Encode(String url)
        {
            var u = new Uri(url);
            var idn = new IdnMapping();
            var hostName = idn.GetAscii(u.Host);
            return url.Replace(u.Host, hostName);
        }
        public String Decode(String url)
        {
            var u = new Uri(url);
            var idn = new IdnMapping();
            var hostName = idn.GetUnicode(u.Host);
            return url.Replace(u.Host, hostName);
        }
    }
}
