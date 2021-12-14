using HigLabo.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    public class SmtpMessageBodyTextCopyFormatter : ISmtpMessageBodyFormatter
    {
        public Boolean IsHtml
        {
            get { return false; }
        }
#if !NETFX_CORE
        public String CreateBodyText(System.Net.Mail.MailMessage message)
        {
            return message.Body;
        }
#endif
        public String CreateBodyText(MailMessage message)
        {
            return message.BodyText;
        }
    }
}
