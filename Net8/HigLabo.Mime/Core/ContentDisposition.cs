using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Mime
{
    public class ContentDisposition : MimeHeaderWithParameter
    {
        public String FileName { get; set; }
        public Boolean IsAttachment
        {
            get { return String.Equals(this.Value, "attachment", StringComparison.OrdinalIgnoreCase); }
        }

        public ContentDisposition()
        {
            this.Value = "";
            this.FileName = "";
        }
        public override string ToString()
        {
            if (String.IsNullOrEmpty(this.Key) == true &&
                String.IsNullOrEmpty(this.Value) == true)
            { return ""; }
            return base.ToString();
        }
    }
}
