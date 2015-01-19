using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    public class SmtpMailHeaderParameter : SmtpMailHeader
    {
        public SmtpMailHeaderParameter()
        {
        }
        public SmtpMailHeaderParameter(String key, String value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
