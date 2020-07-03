using HigLabo.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    public class SmtpMessageSubjectReplyFormatter : ISmtpMessageSubjectFormatter
    {
#if !NETFX_CORE
        public String CreateSubject(System.Net.Mail.MailMessage message)
        {
            return message.Body;
        }
#endif
        public String CreateSubject(MailMessage message)
        {
            return message.BodyText;
        }
    }
}
