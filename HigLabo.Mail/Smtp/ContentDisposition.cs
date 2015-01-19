using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    public class ContentDisposition
    {
        public String Value { get; set; }
        public String FileName { get; set; }

        public Boolean IsAttachment
        {
            get { return String.Equals(this.Value, "attachment", StringComparison.OrdinalIgnoreCase); }
        }
        public List<SmtpMailHeaderParameter> Parameters { get; private set; }

        public ContentDisposition()
        {
            this.Parameters = new List<SmtpMailHeaderParameter>();
        }

#if !NETFX_CORE
        public void SetProperty(System.Net.Mime.ContentDisposition contentDisposition)
        {
            this.Value = contentDisposition.DispositionType;
            this.FileName = contentDisposition.FileName;
            foreach (String key in contentDisposition.Parameters.Keys)
            {
                this.Parameters.Add(new SmtpMailHeaderParameter(key, contentDisposition.Parameters[key].ToString()));
            }
        }
#endif
        public void SetProperty(Mime.ContentDisposition contentDisposition)
        {
            this.Value = contentDisposition.Value;
            this.FileName = contentDisposition.FileName;
            foreach (var p in contentDisposition.Parameters)
            {
                if (String.IsNullOrEmpty(p.Key) == true ||
                    String.Equals(p.Key, "filename", StringComparison.OrdinalIgnoreCase) == true)
                { continue; }
                this.Parameters.Add(new SmtpMailHeaderParameter(p.Key, p.Value));
            }
        }
        public override string ToString()
        {
            return this.Value;
        }
    }
}
