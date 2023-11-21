using HigLabo.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    public class SmtpMessageBodyHtmlReplyFormatter : ISmtpMessageBodyFormatter
    {
        public Boolean IsHtml
        {
            get { return true; }
        }
#if !NETFX_CORE
        public String CreateBodyText(System.Net.Mail.MailMessage message)
        {
            var bodyText = message.Body;
            StringBuilder sb = new StringBuilder(bodyText.Length + 200);

            sb.AppendLine("<hr>");
            sb.AppendFormat("Subject: {0}<br />", message.Subject).AppendLine();
            if (message.From != null)
            {
                sb.AppendFormat("From: {0}<br />", message.From.ToString()).AppendLine();
            }
            if (message.Headers["Date"] != null)
            {
                sb.AppendFormat("Date: {0}<br />", message.Headers["Date"]).AppendLine();
            }
            Int32 count = message.To.Count;
            if (count > 0)
            {
                sb.Append("> To: ");
                for (int i = 0; i < count; i++)
                {
                    var m = message.To[i];
                    sb.Append(m.ToString());
                    if (i < count - 1)
                    {
                        sb.Append("; ");
                    }
                }
                sb.AppendLine("<br />");
            }
            sb.AppendLine("<br />");
            sb.Append(bodyText);

            return sb.ToString();
        }
#endif
        public String CreateBodyText(MailMessage message)
        {
            var bodyText = message.BodyHtml;
            StringBuilder sb = new StringBuilder(bodyText.Length + 200);

            sb.AppendLine("<hr>");
            sb.AppendFormat("Subject: {0}<br />", message.Subject).AppendLine();
            if (message.From != null)
            {
                sb.AppendFormat("From: {0}<br />", message.From.ToString()).AppendLine();
            }
            if (message.Headers["Date"] != null)
            {
                sb.AppendFormat("Date: {0}<br />", message.Headers["Date"]).AppendLine();
            }
            Int32 count = message.To.MailAddresses.Count;
            if (count > 0)
            {
                sb.Append("To: ");
                for (int i = 0; i < count; i++)
                {
                    var m = message.To.MailAddresses[i];
                    sb.Append(m.ToString());
                    if (i < count - 1)
                    {
                        sb.Append("; ");
                    }
                }
                sb.AppendLine("<br />");
            }
            sb.AppendLine("<br />");
            sb.Append(bodyText);

            return sb.ToString();
        }
    }
}
