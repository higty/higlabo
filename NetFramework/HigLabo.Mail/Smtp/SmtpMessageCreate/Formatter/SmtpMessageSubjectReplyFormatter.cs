using HigLabo.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    public class SmtpMessageSubjectCopyFormatter : ISmtpMessageSubjectFormatter
    {
#if !NETFX_CORE
        public String CreateSubject(System.Net.Mail.MailMessage message)
        {
            if (message.Subject.StartsWith("Re:") == true)
            {
                return message.Subject;
            }
            return String.Format("Re: {0}", message.Subject);
        }
#endif
        public String CreateSubject(MailMessage message)
        {
            if (message.Subject.StartsWith("Re:") == true)
            {
                return message.Subject;
            }
            return String.Format("Re: {0}", message.Subject);
        }
    }
}
