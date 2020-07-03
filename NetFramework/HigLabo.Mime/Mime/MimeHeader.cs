using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Mime.Internal;

namespace HigLabo.Mime
{
    public class MimeHeader
    {
        public Byte[] RawData { get; set; }
        public String RawValue { get; set; }
        public String Key { get; set; }
        public String Value { get; set; }
        public virtual Boolean HasParameter
        {
            get { return false; }
        }

        public MimeHeader()
        {
            this.Key = "";
            this.Value = "";
            this.RawValue = "";
        }
        public String GetRawText()
        {
            return Encoding.UTF8.GetString(this.RawData);
        }
        public String GetRawText(Encoding encoding)
        {
            if (this.RawData == null) { return ""; }
            return encoding.GetString(this.RawData);
        }
        public override string ToString()
        {
            return String.Format("{0}: {1}", this.Key, this.Value);
        }
    }
}
