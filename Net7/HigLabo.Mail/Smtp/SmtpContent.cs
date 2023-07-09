using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using HigLabo.Mime;
using HigLabo.Converter;
using HigLabo.Core;

namespace HigLabo.Net.Smtp
{
    /// Represent smtp content.
    /// <summary>
    /// Represent smtp content.
    /// </summary>
    public class SmtpContent
    {
        public static readonly SmtpContentDefaultSettings Default = new SmtpContentDefaultSettings();

        private List<SmtpContent> _Contents;
        public SmtpMailHeaderCollection Headers { get; private set; }
        public List<SmtpContent> Contents
        {
            get { return this._Contents; }
        }
        public String Name
        {
            get { return this.ContentType.Name; }
            set { this.ContentType.Name = value; }
        }
        public String FileName
        {
            get { return this.ContentDisposition.FileName; }
            set { this.ContentDisposition.FileName = value; }
        }
        public String BodyText { get; private set; } = "";
        public Byte[]? BodyData { get; private set; }

        public ContentType ContentType { get; set; }
        public ContentDisposition ContentDisposition { get; set; }
        public TransferEncoding ContentTransferEncoding
        {
            get { return this.Headers.ContentTransferEncoding; }
            set { this.Headers.ContentTransferEncoding = value; }
        }

        public SmtpContent()
            : base()
        {
            this.Headers = new SmtpMailHeaderCollection();
            this._Contents = new List<SmtpContent>();

            this.ContentType = new ContentType("application/octet-stream");
            this.ContentType.CharsetEncoding = Default.ContentTypeCharsetEncoding;
            this.ContentTransferEncoding = Default.ContentTransferEncoding;
            this.ContentDisposition = new ContentDisposition();
        }

        public void LoadText(String text)
        {
            this.ContentType.Value = "text/plain";
            this.BodyText = text;
            this.BodyData = this.ContentType.CharsetEncoding.GetBytes(this.BodyText);
        }
        public void LoadHtml(String html)
        {
            this.ContentType.Value = "text/html";
            this.BodyText = html;
            this.BodyData = this.ContentType.CharsetEncoding.GetBytes(this.BodyText);
        }
        public void LoadFileData(String filePath)
        {
            var fi = new FileInfo(filePath);

            this.ContentType.Value = ContentType.GetContentType(Path.GetExtension(filePath));
            this.ContentType.Name = fi.Name;
            this.ContentDisposition.FileName = fi.Name;
            this.ContentDisposition.Value = "attachment";
            this.ContentTransferEncoding = TransferEncoding.Base64;
            this.BodyData = System.IO.File.ReadAllBytes(filePath);
        }

        public void LoadData(Stream stream)
        {
            var position = stream.Position;
            var bb = stream.ToByteArray();
            if (stream.CanSeek == true)
            {
                stream.Position = position;
            }
            this.LoadData(bb, "application/octet-stream");
        }
        public void LoadData(Byte[] data)
        {
            this.LoadData(data, "application/octet-stream");
        }
        public void LoadData(Byte[] data, String contentType)
        {
            this.LoadData(data, contentType, "attachment");
        }
        public void LoadData(Byte[] data, String contentType, String contentDisposition)
        {
            this.ContentType.Value = contentType;
            this.ContentDisposition.Value = contentDisposition;
            this.ContentTransferEncoding = TransferEncoding.Base64;
            this.BodyData = data;
        }
    }
}
