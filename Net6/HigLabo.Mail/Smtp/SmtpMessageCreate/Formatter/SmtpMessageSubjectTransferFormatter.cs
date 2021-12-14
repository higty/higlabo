using HigLabo.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    public class SmtpMessageSubjectTransferFormatter : ISmtpMessageSubjectFormatter
    {
#if !NETFX_CORE
        public String CreateSubject(System.Net.Mail.MailMessage message)
        {
            return String.Format("Fw: {0}", message.Subject);
        }
#endif
        public String CreateSubject(MailMessage message)
        {
            return String.Format("Fw: {0}", message.Subject);
        }
    }
}
