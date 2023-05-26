using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Mime
{
    public class MimeHeaderParameter
    {
        public String Key { get; set; }
        public String Value { get; set; }
        public String RawValue { get; set; }
        public String RawText { get; set; }
        public Int32? Rfc2231Ordinal { get; set; }
        public Boolean IsEncoded { get; set; }

        public MimeHeaderParameter()
        {
            this.Key = "";
            this.Value = "";
            this.RawValue = "";
            this.RawText = "";
            this.IsEncoded = false;
        }
        public override string ToString()
        {
            return this.RawText;
        }
    }
}
