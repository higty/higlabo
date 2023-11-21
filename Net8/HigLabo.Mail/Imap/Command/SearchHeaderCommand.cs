using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Imap
{
    public class SearchHeaderCommand : SearchByValueCommand
    {
        internal override bool IsEncodeValue
        {
            get { return true; }
        }
        public String FieldName { get; set; }

        public SearchHeaderCommand()
        {
            this.FieldName = "";
            this.Value = "";
        }
        protected override String CreateCommandText()
        {
            var en = this.Encoding;
            if (en == null)
            {
                en = Encoding.UTF8;
            }
            return String.Format("Charset {0} Header {1} ", this.Charset, this.FieldName);
        }
        public override Byte[] GetEncodedValue()
        {
            return this.Encoding.GetBytes(this.Value);
        }
    }
}
