using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Net.Mail;
using HigLabo.Mime;
using System.IO;

namespace HigLabo.Net.Smtp
{
    /// <summary>
    /// 
    /// </summary>
    public class SendMailCommand
    {
        private List<MailAddress> _RcptTo = new List<MailAddress>();
        /// <summary>
        /// 
        /// </summary>
        public MailAddress From { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MailAddress> RcptTo
        {
            get { return _RcptTo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Byte[] Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="text"></param>
        /// <param name="rcptTo"></param>
        public SendMailCommand(String from, Byte[] data, IEnumerable<MailAddress> rcptTo)
        {
            this.From = new MailAddress(from);
            this.RcptTo.AddRange(rcptTo);
            this.Data = data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public SendMailCommand(SmtpMessage message)
        {
            this.From = message.From;
            List<MailAddress> l = new List<MailAddress>();
            l.AddRange(message.To);
            l.AddRange(message.Cc);
            l.AddRange(message.Bcc);
            this.RcptTo.AddRange(l);

            MemoryStream mm = new MemoryStream();
            var sw = new MimeWriter(mm);
            sw.Write(message);
            this.Data = mm.ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="message"></param>
        public SendMailCommand(String from, SmtpMessage message)
        {
            this.From = new MailAddress(from);
            List<MailAddress> l = new List<MailAddress>();
            l.AddRange(message.To);
            l.AddRange(message.Cc);
            l.AddRange(message.Bcc);
            this.RcptTo.AddRange(l);

            MemoryStream mm = new MemoryStream();
            var sw = new MimeWriter(mm);
            sw.Write(message);
            this.Data = mm.ToArray();
        }

        public String GetDataText()
        {
            return Encoding.UTF8.GetString(this.Data);
        }
    }
}
