using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Core;

namespace HigLabo.Net.Imap
{
    public class SearchByValueCommand : SearchCommand
    {
        internal override bool IsEncodeValue
        {
            get { return true; }
        }
        public SearchByValueCommandKey Key { get; set; }
        public String Value { get; set; }
        public Encoding Encoding { get; set; }
        public String Charset
        {
            get
            {
                if (this.Encoding == null)
                {
                    return "";
                }
                return this.Encoding.WebName;
            }
        }

        public SearchByValueCommand()
            : this(SearchByValueCommandKey.Text, "", Encoding.UTF8)
        {
        }
        public SearchByValueCommand(SearchByValueCommandKey key, String value)
            : this(key, value, Encoding.UTF8)
        {
        }
        public SearchByValueCommand(SearchByValueCommandKey key, String value, Encoding encoding)
        {
            this.Key = SearchByValueCommandKey.Text;
            this.Value = "";
            this.Encoding = encoding;
        }
        protected override String CreateCommandText()
        {
            var en = this.Encoding;
            if (en == null)
            {
                en = Encoding.UTF8;
            }
            return String.Format("Charset {0} {1} ", this.Charset, this.Key.ToStringFromEnum());
        }
        public override Byte[] GetEncodedValue()
        {
            return this.Encoding.GetBytes(this.Value); 
        }
    }
}
