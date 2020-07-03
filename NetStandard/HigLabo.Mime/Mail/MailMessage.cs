using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Mime
{
    public class MailMessage : MimeMessage
    {
        public new MailHeaderCollection Headers
        {
            get { return base.Headers as MailHeaderCollection; }
        }

        public DateTimeOffset Date
        {
            get { return this.Headers.Date; }
        }
        public String Subject
        {
            get { return this.Headers.Subject; }
        }
        public String MessageID
        {
            get { return this.Headers.MessageID; }
        }
        public MailAddress From
        {
            get { return this.Headers.From; }
        }
        public MailAddress Sender
        {
            get { return this.Headers.Sender; }
        }
        public MailAddress ReturnPath
        {
            get { return this.Headers.ReturnPath; }
        }
        public MailAddressCollection ReplyTo
        {
            get { return this.Headers.ReplyTo; }
        }
        public MailAddressCollection To
        {
            get { return this.Headers.To; }
        }
        public MailAddressCollection Cc
        {
            get { return this.Headers.Cc; }
        }

        public MailMessage()
            : base(new MailHeaderCollection())
        {
        }
        protected MailMessage(MimeHeaderCollection headers)
            : base(headers) { }
    }
}
