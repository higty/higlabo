using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Mime;

namespace HigLabo.Net.Smtp
{
    public interface ISmtpMessageSubjectFormatter
    {
#if !NETFX_CORE
        String CreateSubject(System.Net.Mail.MailMessage message);
#endif
        String CreateSubject(MailMessage message);
    }
}
