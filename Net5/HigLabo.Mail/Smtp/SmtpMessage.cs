using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
#if !NETFX_CORE
using System.Security.Cryptography.X509Certificates;
#endif
using HigLabo.Mime;
using HigLabo.Net.Mail;
using System.IO;
using HigLabo.Converter;
using HigLabo.Net.Internal;

namespace HigLabo.Net.Smtp
{
    /// Represent smtp message.
    /// <summary>
    /// Represent smtp message.
    /// </summary>
    public class SmtpMessage
    {
        public static readonly SmtpMessageDefaultSettings Default = new SmtpMessageDefaultSettings();
        
        private List<SmtpContent> _Contents;
        private List<MailAddress> _To = new List<MailAddress>();
        private List<MailAddress> _ReplyTo = new List<MailAddress>();
        private List<MailAddress> _Cc = new List<MailAddress>();
        private List<MailAddress> _Bcc = new List<MailAddress>();
        private SmtpContent _BodyTextContent = null;
        public SmtpMailHeaderCollection Headers { get; private set; }
        public DateTimeOffset Date
        {
            get { return this.Headers.Date; }
            set { this.Headers.Date = value; }
        }
        public MailAddress From
        {
            get { return this.Headers.From; }
            set { this.Headers.From = value; }
        }
        public MailAddress Sender
        {
            get { return this.Headers.Sender; }
            set { this.Headers.Sender = value; }
        }
        public MailPriority Priority
        {
            get { return this.Headers.Priority; }
            set { this.Headers.Priority = value; }
        }
        public List<MailAddress> To
        {
            get { return this._To; }
        }
        public List<MailAddress> ReplyTo
        {
            get { return this._ReplyTo; }
        }
        public List<MailAddress> Cc
        {
            get { return this._Cc; }
        }
        public List<MailAddress> Bcc
        {
            get { return this._Bcc; }
        }
        public Boolean IsSigned { get; set; }
        public Boolean IsEncrypted { get; set; }
        public String Subject
        {
            get { return this.Headers.Subject; }
            set { this.Headers.Subject = value; }
        }
        public ContentType ContentType { get; set; }
        public TransferEncoding ContentTransferEncoding
        {
            get { return this.Headers.ContentTransferEncoding; }
            set { this.Headers.ContentTransferEncoding = value; }
        }
        public String BodyText
        {
            get { return this._BodyTextContent.BodyText; }
            set
            {
                if (this.Contents.Contains(_BodyTextContent) == false)
                {
                    throw new InvalidOperationException("BodyTextContent is removed from Contents collection.");
                }
                this._BodyTextContent.LoadText(value);
            }
        }
        public List<SmtpContent> Contents
        {
            get { return this._Contents; }
        }

		public SmtpMessage()
        {
            this.Initialize();
        }
		public SmtpMessage(String mailFrom, String to, String cc, String subject, String bodyText)
        {
            this.Initialize();
            this.From = new MailAddress(mailFrom);
            if (String.IsNullOrEmpty(to) == false)
            {
                this.To.AddRange(MailAddress.CreateMailAddressList(to));
            }
            if (String.IsNullOrEmpty(cc) == false)
            {
                this.Cc.AddRange(MailAddress.CreateMailAddressList(cc));
            }
            this.Subject = subject;
            this.BodyText = bodyText;
        }
        private void Initialize()
        {
            this.Headers = new SmtpMailHeaderCollection();
            this._Contents = new List<SmtpContent>();

            this.Headers.Add("MIME-Version", "1.0");

            this.Date = DateTimeOffset.Now;
            this.Subject = "";
            this.ContentType = new ContentType("multipart/mixed");
            this.ContentType.Boundary = MimeWriter.GenerateBoundary();
            _BodyTextContent = new SmtpContent();
            this.Contents.Add(_BodyTextContent);

            this.ContentType.CharsetEncoding = Default.ContentTypeCharsetEncoding;
            this.ContentTransferEncoding = Default.ContentTransferEncoding;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        public void SetBodyAsHtmlContent(String html)
        {
            _BodyTextContent.LoadHtml(html);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="html"></param>
        public void SetBodyAsAlternativeContent(String text, String html)
        {
            SmtpContent ct = null;

            _BodyTextContent.ContentType.Value = "multipart/alternative";
            _BodyTextContent.Contents.Clear();

            ct = new SmtpContent();
            ct.LoadText(text);
            _BodyTextContent.Contents.Add(ct);

            ct = new SmtpContent();
            ct.LoadHtml(html);
            _BodyTextContent.Contents.Add(ct);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String GetRawText()
        {
            return GetRawText(Encoding.UTF8);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public String GetRawText(Encoding encoding)
        {
            MemoryStream mm = new MemoryStream();
            var sw = new MimeWriter(mm);
            sw.Write(this);
            return encoding.GetString(mm.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String GetRawBodyText()
        {
            return this.GetRawBodyText(Encoding.UTF8);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public String GetRawBodyText(Encoding encoding)
        {
            MemoryStream mm = new MemoryStream();
            var sw = new MimeWriter(mm);
            sw.WriteBody(this);
            return encoding.GetString(mm.ToArray());
        }

        public static SmtpMessage Create(MailMessage message)
        {
            var m = MailAddress.TryCreate(message.From.ToString());
            return Create(message, new SmtpMessageCreateCondition(m, SmtpMessageCreateMode.Copy, false));
        }
        public static SmtpMessage Create(MailMessage message, MailAddress sender, SmtpMessageCreateMode mode, Boolean isBodyHtml)
        {
            return Create(message, new SmtpMessageCreateCondition(sender, mode, isBodyHtml));
        }
        public static SmtpMessage Create(MailMessage message, SmtpMessageCreateCondition condition)
        {
            SmtpMessage mg = new SmtpMessage();

            mg.Subject = condition.SubjectFormatter.CreateSubject(message);
            mg.From = condition.Sender;
            mg.Sender = condition.Sender;
            mg.ContentType.SetProperty(message.ContentType);
            mg.ContentTransferEncoding = message.ContentTransferEncoding;
            if (condition.BodyFormatter.IsHtml == true)
            {
                mg._BodyTextContent.LoadHtml(condition.BodyFormatter.CreateBodyText(message));
            }
            else
            {
                mg.BodyText = condition.BodyFormatter.CreateBodyText(message);
            }

            AddMailAddress(message, condition.To, mg.To);
            AddMailAddress(message, condition.Cc, mg.Cc);
            AddMailAddress(message, condition.Bcc, mg.Bcc);

            if (condition.CopyContents == true)
            {
                foreach (var item in message.Contents)
                {
                    var ct = new SmtpContent();
                    ct.LoadData(item.RawData);
                    ct.ContentType.SetProperty(item.ContentType);
                    ct.ContentDisposition.SetProperty(item.ContentDisposition);
                    mg.Contents.Add(ct);
                }
            }

            return mg;
        }
        private static void AddMailAddress(MailMessage message, MailAddressCreateCondition condition, List<MailAddress> target)
        {
            Func<MailAddress, MailAddress, Boolean> f = (x, y) => String.Equals(x.Value, y.Value, StringComparison.OrdinalIgnoreCase);

            if (condition.UseFrom == true &&
                message.From != null)
            {
                target.AddIfNotExist(new MailAddress(message.From.ToString()), f);
            }
            if (condition.UseSender == true &&
                message.Sender != null)
            {
                target.AddIfNotExist(new MailAddress(message.Sender.ToString()), f);
            }
            if (condition.UseTo == true)
            {
                foreach (var item in message.To.MailAddresses)
                {
                    var m = MailAddress.TryCreate(item.ToString());
                    if (m == null) { continue; }
                    target.AddIfNotExist(m, f);
                }
            }
            if (condition.UseCc == true)
            {
                foreach (var item in message.Cc.MailAddresses)
                {
                    var m = MailAddress.TryCreate(item.ToString());
                    if (m == null) { continue; }
                    target.AddIfNotExist(m, f);
                }
            }
            if (condition.ExcludeSender == true)
            {
                target.RemoveAll(el => el.Value == condition.Sender.Value);
            }
        }

#if !NETFX_CORE
        public static SmtpMessage Create(System.Net.Mail.MailMessage message)
        {
            var m = MailAddress.TryCreate(message.From.ToString());
            return Create(message, new SmtpMessageCreateCondition(m, SmtpMessageCreateMode.Copy, message.IsBodyHtml));
        }
        public static SmtpMessage Create(System.Net.Mail.MailMessage message, MailAddress sender, SmtpMessageCreateMode mode)
        {
            return Create(message, new SmtpMessageCreateCondition(sender, mode, message.IsBodyHtml));
        }
        public static SmtpMessage Create(System.Net.Mail.MailMessage message, SmtpMessageCreateCondition condition)
        {
            SmtpMessage mg = new SmtpMessage();

            mg.Subject = condition.SubjectFormatter.CreateSubject(message);
            mg.From = condition.Sender;
            mg.Sender = condition.Sender;
            mg.ContentType.CharsetEncoding = message.BodyEncoding;
            mg.Priority = message.Priority.Cast();

            if (condition.BodyFormatter.IsHtml == true)
            {
                var html = condition.BodyFormatter.CreateBodyText(message);
                mg._BodyTextContent.LoadHtml(html);
            }
            else
            {
                mg.BodyText = condition.BodyFormatter.CreateBodyText(message);
            }
            AddMailAddress(message, condition.To, mg.To);
            AddMailAddress(message, condition.Cc, mg.Cc);
            AddMailAddress(message, condition.Bcc, mg.Bcc);

            if (condition.CopyAlternateViews == true)
            {
                foreach (var item in message.AlternateViews)
                {
                    var ct = new SmtpContent();
                    ct.LoadData(item.ContentStream);

                    ct.ContentTransferEncoding = item.TransferEncoding.Cast();
                    ct.ContentType.SetProperty(item.ContentType);

                    mg.Contents.Add(ct);
                }
            }
            if (condition.CopyAttachments == true)
            {
                foreach (var item in message.Attachments)
                {
                    var ct = new SmtpContent();
                    ct.LoadData(item.ContentStream);

                    ct.ContentTransferEncoding = item.TransferEncoding.Cast();
                    ct.ContentType.SetProperty(item.ContentType);
                    ct.ContentDisposition.SetProperty(item.ContentDisposition);
                    mg.Contents.Add(ct);
                }
            }
            return mg;
        }
        private static void AddMailAddress(System.Net.Mail.MailMessage message, MailAddressCreateCondition condition, List<MailAddress> target)
        {
            Func<MailAddress, MailAddress, Boolean> f = (x, y) => String.Equals(x.Value, y.Value, StringComparison.OrdinalIgnoreCase);
            
            if (condition.UseFrom == true &&
                message.From != null)
            {
                var m = MailAddress.TryCreate(message.From.ToString());
                if (m != null)
                {
                    target.AddIfNotExist(m, f);
                }
            }
            if (condition.UseSender == true &&
                message.Sender != null)
            {
                var m = MailAddress.TryCreate(message.Sender.ToString());
                if (m != null)
                {
                    target.AddIfNotExist(m, f);
                }
            }
            if (condition.UseTo == true)
            {
                foreach (var item in message.To)
                {
                    var m = MailAddress.TryCreate(item.ToString());
                    if (m == null) { continue; }
                    target.AddIfNotExist(m, f);
                }
            }
            if (condition.UseCc == true)
            {
                foreach (var item in message.CC)
                {
                    var m = MailAddress.TryCreate(item.ToString());
                    if (m == null) { continue; }
                    target.AddIfNotExist(m, f);
                }
            }
            if (condition.UseBcc == true)
            {
                foreach (var item in message.Bcc)
                {
                    var m = MailAddress.TryCreate(item.ToString());
                    if (m == null) { continue; }
                    target.AddIfNotExist(m, f);
                }
            }
        }
#endif
    }
}
