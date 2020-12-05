using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Mime.Internal;
using System.IO;
using HigLabo.Converter;

namespace HigLabo.Mime
{
    public class MimeContent
    {
        private ContentType _ContentType = null;
        private ContentDisposition _ContentDisposition = null;
        
        public MimeHeaderCollection Headers { get; private set; }
        public List<MimeContent> Contents { get; private set; }

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
        public String FileName
        {
            get
            {
                return this.ContentDisposition.FileName;
            }
        }
        public String Name
        {
            get
            {
                return this.ContentType.Name;
            }
        }
        public Byte[] RawData { get; internal set; }
        public Byte[] BodyData { get; internal set; }
        public String BodyText { get; set; }
        public String BodyRawText { get; set; }
        public String TextBeforeContent { get; set; }
        public MailMessage MailMessage { get; internal set; }

        public MimeContent()
        {
            this.Headers = new MimeHeaderCollection();
            this.Contents = new List<MimeContent>();
            this.BodyRawText = "";
            this.BodyText = "";
        }
        public String GetRawText()
        {
            return Encoding.UTF8.GetString(this.RawData);
        }
        public String GetRawText(Encoding encoding)
        {
            if (this.RawData == null) { return ""; }
            return encoding.GetString(this.RawData);
        }
        /// <summary>
        /// Decode binary data and output as file to specify file path.
        /// バイナリデータをデコードして指定した物理パスにファイルとして保存します。
        /// </summary>
        /// <param name="filePath"></param>
        public void SaveTo(String filePath)
        {
            using (var stm = new FileStream(filePath, FileMode.Create))
            {
                var bb = this.GetDecodedData();
                this.WriteTo(stm, bb, true);
            }
        }
        /// <summary>
        /// Decode binary data and output as file to specify file path.
        /// バイナリデータをデコードして指定したディレクトリにファイルとして保存します。
        /// </summary>
        /// <param name="directoryPath"></param>
        public void SaveToDirectory(String directoryPath)
        {
            using (var stm = new FileStream(Path.Combine(directoryPath, this.FileName), FileMode.Create))
            {
                var bb = this.GetDecodedData();
                this.WriteTo(stm, bb, true);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="fileName"></param>
        public void SaveToDirectory(String directoryPath, String fileNameWithoutExtension)
        {
            var fileName = fileNameWithoutExtension + Path.GetExtension(this.FileName);
            using (var stm = new FileStream(Path.Combine(directoryPath, fileName), FileMode.Create))
            {
                var bb = this.GetDecodedData();
                this.WriteTo(stm, bb, true);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="encoding"></param>
        public void SaveAsTextFile(String filePath, Encoding encoding)
        {
            using (var stm = new FileStream(filePath, FileMode.Create))
            {
                var bb = encoding.GetBytes(this.BodyText);
                this.WriteTo(stm, bb, true);
            }
        }
        /// <summary>
        /// Get decoded BodyData by ContentTransferEncoding
        /// </summary>
        /// <returns></returns>
        public Byte[] GetDecodedData()
        {
            Byte[] bb = this.BodyData;

            if (bb == null) throw new InvalidOperationException("BodyData is not loaded.Please ensure to set MimeParser.Filter.LoadContentBodyData = true when you download mail.");

            if (this.ContentTransferEncoding == TransferEncoding.Base64)
            {
                var cv = new Base64Converter(9000);
                bb = cv.Decode(bb);
            }
            else if (this.ContentTransferEncoding == TransferEncoding.QuotedPrintable)
            {
                var cv = new QuotedPrintableConverter(9000, QuotedPrintableConvertMode.Default);
                bb = cv.Decode(bb);
            }
            return bb;
        }
        /// <summary>
        /// Output data to specified stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="encoding"></param>
        public void WriteTo(Stream stream, Encoding encoding)
        {
            if (this.ContentType.IsText == true)
            {
                var bb = encoding.GetBytes(this.BodyText);
                this.WriteTo(stream, bb, false);
            }
            else if (this.ContentDisposition.IsAttachment == true)
            {
                var bb = this.GetDecodedData();
                this.WriteTo(stream, bb, false);
            }
        }
        /// <summary>
        /// Output data to specified stream and close stream
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="data"></param>
        /// <param name="isClose"></param>
        private void WriteTo(Stream stream, Byte[] data, Boolean isClose)
        {
            if (data == null)
            { throw new ArgumentNullException("data must not be null."); }

            BinaryWriter sw = null;
            try
            {
                sw = new BinaryWriter(stream);
                sw.Write(data);
                sw.Flush();
            }
            finally
            {
                if (isClose == true)
                {
                    sw.Dispose();
                }
            }
        }
        public override string ToString()
        {
            if (this.ContentType != null)
            {
                return "MimeContent " + this.ContentType.ToString();
            }
            if (this.Headers.Count > 0)
            {
                return "MimeContent " + this.Headers[0].ToString();
            }
            return "MimeContent " + base.ToString();
        }
    }
}
