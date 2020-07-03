using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    public class SmtpMailHeader
    {
        public String Key { get; set; }
        public String Value { get; set; }
        public SmtpMailHeader()
        {
        }
        public SmtpMailHeader(String key, String value)
        {
            this.Key = key;
            this.Value = value;
        }
        public override string ToString()
        {
            return String.Format("{0}: {1}", this.Key, this.Value);
        }
    }
}
