using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using HigLabo.Mime;

namespace HigLabo.Net.Smtp
{
    public interface ISmtpMessageBodyFormatter
    {
        Boolean IsHtml { get; }

#if !NETFX_CORE
        String CreateBodyText(System.Net.Mail.MailMessage message);
#endif
        String CreateBodyText(MailMessage message);
    }
}
