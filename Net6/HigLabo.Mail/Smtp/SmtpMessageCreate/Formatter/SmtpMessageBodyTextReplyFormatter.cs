using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HigLabo.Core;
using HigLabo.Mime;

namespace HigLabo.Net.Smtp
{
    public class SmtpMessageBodyTextReplyFormatter : ISmtpMessageBodyFormatter
    {
        public Boolean IsHtml
        {
            get { return false; }
        }
#if !NETFX_CORE
        public String CreateBodyText(System.Net.Mail.MailMessage message)
        {
            var bodyText = message.Body;
            StringBuilder sb = new StringBuilder(bodyText.Length + 200);
            StringReader sr = new StringReader(bodyText);

            sb.AppendLine("________________________________");
            sb.AppendFormat("> Subject: {0}", message.Subject).AppendLine();
            if (message.From != null)
            {
                sb.AppendFormat("> From: {0}", message.From.ToString()).AppendLine();
            }
            if (message.Headers["Date"] != null)
            {
                sb.AppendFormat("> Date: {0}", message.Headers["Date"]).AppendLine();
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
                sb.AppendLine();
            }
            sb.AppendLine("> ");

            while (true)
            {
                var line = sr.ReadLine();
                sb.Append("> ");
                sb.AppendLine(line);
                if (sr.Peek() == -1) { break; }
            }

            return sb.ToString();
        }
#endif
        public String CreateBodyText(MailMessage message)
        {
            var bodyText = message.BodyText;
            StringBuilder sb = new StringBuilder(bodyText.Length + 200);
            StringReader sr = new StringReader(bodyText);

            sb.AppendLine("________________________________");
            sb.AppendFormat("> Subject: {0}", message.Subject).AppendLine();
            if (message.From != null)
            {
                sb.AppendFormat("> From: {0}", message.From.ToString()).AppendLine();
            }
            if (message.Headers["Date"] != null)
            {
                sb.AppendFormat("> Date: {0}", message.Headers["Date"]).AppendLine();
            }
            Int32 count = message.To.MailAddresses.Count;
            if (count > 0)
            {
                sb.Append("> To: ");
                for (int i = 0; i < count; i++)
                {
                    var m = message.To.MailAddresses[i];
                    sb.Append(m.ToString());
                    if (i < count - 1)
                    {
                        sb.Append("; ");
                    }
                }
                sb.AppendLine();
            }
            sb.AppendLine("> ");

            while (true)
            {
                var line = sr.ReadLine();
                sb.Append("> ");
                sb.AppendLine(line);
                if (sr.Peek() == -1) { break; }
            }

            return sb.ToString();
        }
    }
}
