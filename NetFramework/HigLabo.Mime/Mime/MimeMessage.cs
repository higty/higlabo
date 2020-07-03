using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Mime.Internal;

namespace HigLabo.Mime
{
    public class MimeMessage
    {
        private String _BodyText = null;
        private String _BodyRawText = null;
        private String _BodyHtml = null;
        private String _BodyRawHtml = null;
        private ContentType _ContentType = null;
        private ContentDisposition _ContentDisposition = null;

        public MimeHeaderCollection Headers { get; private set; }
        public List<MimeContent> Contents { get; private set; }

        /// <summary>
        /// Get all MimeContent by recursive aggregate from Contents property
        /// </summary>
        public IEnumerable<MimeContent> AllFiles
        {
            get
            {
                return this.GetMimeContents();
            }
        }
        /// <summary>
        /// Get all attachment files that ContentDisposition.IsAttachment is true by recursive aggregate from Contents property
        /// </summary>
        public IEnumerable<MimeContent> AttachmentFiles
        {
            get
            {
                return this.GetMimeContents().Where(el => el.ContentDisposition.IsAttachment == true);
            }
        }
        /// <summary>
        /// Get all attachment files that ContentType.IsImage is true by recursive aggregate from Contents property
        /// </summary>
        public IEnumerable<MimeContent> ImageFiles
        {
            get
            {
                return this.GetMimeContents().Where(el => el.ContentType.IsImage == true);
            }
        }
        /// <summary>
        /// Get all attachment files that ContentType.IsText is true by recursive aggregate from Contents property
        /// </summary>
        public IEnumerable<MimeContent> TextFiles
        {
            get
            {
                return this.GetMimeContents().Where(el => el.ContentType.IsText == true);
            }
        }
        /// <summary>
        /// Get all attachment files that ContentType.IsHtml is true by recursive aggregate from Contents property
        /// </summary>
        public IEnumerable<MimeContent> HtmlFiles
        {
            get
            {
                return this.GetMimeContents().Where(el => el.ContentType.IsHtml == true);
            }
        }
        /// <summary>
        /// Get all transfered message as ContentType="message/rfc822" by recursive aggregate from Contents property
        /// </summary>
        public IEnumerable<MailMessage> TransferedMailMessages
        {
            get
            {
                return this.GetMimeContents().Where(el => el.MailMessage != null).Select(el => el.MailMessage);
            }
        }

        public ContentType ContentType
        {
            get
            {
                if (_ContentType == null)
                {
                    _ContentType = this.Headers.GetValueOrNull("Content-Type") as ContentType;
                    if (_ContentType == null)
                    {
                        _ContentType = new ContentType();
                    }
                }
                return _ContentType;
            }
        }
        public ContentDisposition ContentDisposition
        {
            get
            {
                if (_ContentDisposition == null)
                {
                    _ContentDisposition = this.Headers.GetValueOrNull("Content-Disposition") as ContentDisposition;
                    if (_ContentDisposition == null)
                    {
                        _ContentDisposition = new ContentDisposition();
                    }
                }
                return _ContentDisposition;
            }
        }
        public TransferEncoding ContentTransferEncoding
        {
            get
            {
                switch (this.Headers["Content-Transfer-Encoding"].ToLower())
                {
                    case "7bit": return TransferEncoding.SevenBit;
                    case "8bit": return TransferEncoding.EightBit;
                    case "quoted-printable": return TransferEncoding.QuotedPrintable;
                    case "base64": return TransferEncoding.Base64;
                    default: return TransferEncoding.None;
                }
            }
        }

        public Byte[] RawData { get; set; }
        public String BodyRawText
        {
            get
            {
                if (_BodyRawText == null)
                {
                    this.LoadBodyText();
                }
                return _BodyRawText;
            }
            internal set { _BodyRawText = value; }
        }
        public String BodyText
        {
            get
            {
                if (_BodyText == null)
                {
                    this.LoadBodyText();
                }
                return _BodyText;
            }
            internal set { _BodyText = value; }
        }
        public String BodyRawHtml
        {
            get
            {
                if (_BodyRawHtml == null)
                {
                    this.LoadBodyHtml();
                }
                return _BodyRawHtml;
            }
            internal set { _BodyRawHtml = value; }
        }
        public String BodyHtml
        {
            get
            {
                if (_BodyHtml == null)
                {
                    this.LoadBodyHtml();
                }
                return _BodyHtml;
            }
            internal set { _BodyHtml = value; }
        }
        public String TextBeforeMimeContent { get; set; }

        public MimeMessage()
            : this(new MimeHeaderCollection())
        {
        }
        protected MimeMessage(MimeHeaderCollection headers)
        {
            this.Headers = headers;
            this.Contents = new List<MimeContent>();
        }
        public String GetRawText()
        {
            return this.GetRawText(Encoding.UTF8);
        }
        public String GetRawText(Encoding encoding)
        {
            if (this.RawData == null) throw new InvalidOperationException("RawData is not loaded.Please ensure to set MimeParser.Filter.LoadContentBodyData = true when you download mail.");
            return encoding.GetString(this.RawData);
        }
        private void LoadBodyText()
        {
            var mc = this.GetMimeContents().Where(el => el.ContentType != null).FirstOrDefault(el => el.ContentType.IsText);
            if (mc == null)
            {
                _BodyRawText = "";
                _BodyText = "";
            }
            else
            {
                _BodyRawText = mc.BodyRawText;
                _BodyText = mc.BodyText;
            }
        }
        private void LoadBodyHtml()
        {
            var mc = this.GetMimeContents().Where(el => el.ContentType != null).FirstOrDefault(el => el.ContentType.IsHtml);
            if (mc == null)
            {
                _BodyRawHtml = "";
                _BodyHtml = "";
            }
            else
            {
                _BodyRawHtml = mc.BodyRawText;
                _BodyHtml = mc.BodyText;
            }
        }

        private IEnumerable<MimeContent> GetMimeContents()
        {
            return this.GetMimeContents(this.Contents);
        }
        private IEnumerable<MimeContent> GetMimeContents(List<MimeContent> contents)
        {
            foreach (var content in contents)
            {
                yield return content;
                foreach (var item in GetMimeContents(content.Contents))
                {
                    yield return item;
                }
            }
        }
    }
}
