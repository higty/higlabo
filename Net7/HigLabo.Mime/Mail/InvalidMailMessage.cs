using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Mime
{
    public class InvalidMailMessage : MailMessage
    {
        public String ResponseText { get; private set; }
        public String ParseText { get; private set; }

        public InvalidMailMessage(MimeMessage message, String responseText, String parseText)
            : base(message.Headers)
        {
            this.RawData = message.RawData;
            this.ResponseText = responseText;
            this.ParseText = parseText;
        }
        public override string ToString()
        {
            return this.ParseText + Environment.NewLine + Environment.NewLine + this.GetRawText();
        }
    }
}
