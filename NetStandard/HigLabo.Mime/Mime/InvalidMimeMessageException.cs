using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Mime
{
    public class InvalidMimeMessageException: Exception
    {
        public MimeMessage MimeMessage { get; private set; }
        public String ParseText { get; private set; }

        public InvalidMimeMessageException(MimeMessage message, String parseText)
        {
            this.MimeMessage = message;
            this.ParseText = parseText;
        }
        public override string ToString()
        {
            return this.ParseText + Environment.NewLine + Environment.NewLine + this.MimeMessage.GetRawText();
        }
    }
}
