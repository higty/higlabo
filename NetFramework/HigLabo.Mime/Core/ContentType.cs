using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Mime
{
    public class ContentType : MimeHeaderWithParameter
    {
        public String MainValue { get; set; }
        public String SubValue { get; set; }
        public String Name { get; set; }
        public String Boundary { get; set; }
        public String Charset { get; set; }
        public Encoding CharsetEncoding { get; set; }
        public Boolean FormatFlowed { get; set; }
        public Boolean DeleteSpace { get; set; }
        public Boolean IsText
        {
            get { return String.Equals(this.MainValue, "text", StringComparison.OrdinalIgnoreCase); }
        }
        public Boolean IsHtml
        {
            get
            {
                return String.Equals(this.MainValue, "text", StringComparison.OrdinalIgnoreCase) &&
                    String.Equals(this.SubValue, "html", StringComparison.OrdinalIgnoreCase);
            }
        }
        public Boolean IsImage
        {
            get { return String.Equals(this.MainValue, "image", StringComparison.OrdinalIgnoreCase); }
        }
        public Boolean IsRfc822
        {
            get
            {
                return String.Equals(this.MainValue, "message", StringComparison.OrdinalIgnoreCase) &&
                    String.Equals(this.SubValue, "rfc822", StringComparison.OrdinalIgnoreCase);
            }
        }

        public ContentType()
        {
            this.Value = "";
            this.MainValue = "";
            this.SubValue = "";
            this.Name = "";
            this.Boundary = "";
            this.Charset = "";
            this.FormatFlowed = false;
            this.DeleteSpace = false;
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
