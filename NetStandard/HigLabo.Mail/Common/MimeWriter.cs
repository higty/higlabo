using HigLabo.Converter;
using HigLabo.Mime;
using HigLabo.Net.Mail;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
#if NETFX_CORE
using Windows.Security.Cryptography;
#else
using System.Security.Cryptography.X509Certificates;
#endif
using HigLabo.Core;

namespace HigLabo.Net.Smtp
{
    public class MimeWriter
    {
        private class ByteData
        {
            public static readonly Byte[] NewLine = new Byte[] { 13, 10 };
            public static readonly Byte[] NewLineTab = new Byte[] { 13, 10, 9 };
            public static readonly Byte[] NewLineSpace = new Byte[] { 13, 10, 32 };
            public static readonly Byte[] ColonSpace = new Byte[] { 58, 32 };
            public static readonly Byte[] Charset = GetAsciiBytes("charset=");
            public static readonly Byte[] Boundary = GetAsciiBytes("boundary=");
            public static readonly Byte[] EndOfEncodedHeaderBytes = GetAsciiBytes("?=");
            /// <summary>
            /// "Content-Transfer-Encoding: base64"
            /// </summary>
            public static readonly Byte[] ContentTransferEncodingIsBase64 = null;
            /// <summary>
            /// "Content-Type: application/x-pkcs7-signature; name=\"smime.p7s\""
            /// </summary>
            public static readonly Byte[] ContentTypeApplicationXpkcs7Signature = null;
            /// <summary>
            /// "Content-Type: multipart/signed; protocol=\"application/x-pkcs7-signature\"; micalg=SHA1; boundary="
            /// </summary>
            public static readonly Byte[] ContentTypeMultipartSignedProtocolApplicationXpkcs7Signature = null;
            /// <summary>
            /// "Content-Disposition: attachment; filename=\"smime.p7s\""
            /// </summary>
            public static readonly Byte[] ContentDispositionAttachmentFileNameIsSmimeP7s = null;
            /// <summary>
            /// "Content-Disposition: attachment; filename=\"smime.p7m\""
            /// </summary>
            public static readonly Byte[] ContentDispositionAttachmentFileNameIsSmimeP7m = null;
            /// <summary>
            /// "Content-Type: application/x-pkcs7-mime; smime-type=enveloped-data; name=\"smime.p7m\""
            /// </summary>
            public static readonly Byte[] ContentTypeApplicationXpkcs7Mime = null;
            public static readonly Byte[] ContentDisposition = null;
            static ByteData()
            {
                ContentTypeApplicationXpkcs7Signature = Encoding.UTF8.GetBytes("Content-Type: application/x-pkcs7-signature; name=\"smime.p7s\"");
                ContentTransferEncodingIsBase64 = Encoding.UTF8.GetBytes("Content-Transfer-Encoding: base64");
                ContentTypeMultipartSignedProtocolApplicationXpkcs7Signature = Encoding.UTF8.GetBytes("Content-Type: multipart/signed; protocol=\"application/x-pkcs7-signature\"; micalg=SHA1; boundary=");
                ContentDispositionAttachmentFileNameIsSmimeP7s = Encoding.UTF8.GetBytes("Content-Disposition: attachment; filename=\"smime.p7s\"");
                ContentDispositionAttachmentFileNameIsSmimeP7m = Encoding.UTF8.GetBytes("Content-Disposition: attachment; filename=\"smime.p7m\"");
                ContentTypeApplicationXpkcs7Mime = Encoding.UTF8.GetBytes("Content-Type: application/x-pkcs7-mime; smime-type=enveloped-data; name=\"smime.p7m\"");
            }
        }
        public static readonly String NewLine = "\r\n";
        private static Action<MimeWriter> _Initialize = null;
        public static readonly MimeWriterDefaultSettings Default = new MimeWriterDefaultSettings();
        public static readonly Int32 MaxCharCountPerRow = 76;

        private Stream _Stream = null;
        private Base64Converter _Base64HeaderConverter = null;
        private Base64Converter _Base64BodyConverter = null;
        private QuotedPrintableConverter _QuotedPrintableHeaderConverter = null;
        private QuotedPrintableConverter _QuotedPrintableBodyConverter = null;

        public Int32 Base64ConverterBufferSize
        {
            get { return _Base64BodyConverter.BufferSize; }
            set { _Base64BodyConverter.BufferSize = value; }
        }
        public Int32 QuotedPrintableConverterBufferSize
        {
            get { return _QuotedPrintableBodyConverter.BufferSize; }
            set { _QuotedPrintableBodyConverter.BufferSize = value; }
        }
        public Rfc2047Encoding HeaderRfc2047Encoding { get; set; }
        public Encoding HeaderEncoding { get; set; }
        public FileNameEncoding FileNameEncoding { get; set; }
        public MimeHeaderParameterEncoding MimeHeaderParameterEncoding { get; set; }
#if !NETFX_CORE
        public DkimSignatureGenerator DkimSignatureGenerator { get; set; }
#endif

        public static void Initialize(Action<MimeWriter> initializer)
        {
            _Initialize = initializer;
        }
        public MimeWriter(Stream stream)
        {
            _Stream = stream;
            _Base64HeaderConverter = new Base64Converter(200);
            _Base64HeaderConverter.InsertNewline = false;
            _Base64BodyConverter = new Base64Converter(12000);
            _Base64BodyConverter.InsertNewline = true;
            _QuotedPrintableHeaderConverter = new QuotedPrintableConverter(200, QuotedPrintableConvertMode.Header);
            _QuotedPrintableHeaderConverter.InsertNewline = false;
            _QuotedPrintableBodyConverter = new QuotedPrintableConverter(2000, QuotedPrintableConvertMode.Default);

            this.HeaderEncoding = Default.HeaderEncoding;
            this.HeaderRfc2047Encoding = Default.HeaderRfc2047Encoding;
            this.FileNameEncoding = Default.FileNameEncoding;
            this.MimeHeaderParameterEncoding = Default.MimeHeaderParameterEncoding;

            if (_Initialize != null)
            {
                _Initialize(this);
            }
        }

        public void Write(SmtpMessage message)
        {
            this.Write(_Stream, message);
        }
        private void Write(Stream stream, SmtpMessage message)
        {
            var mg = message;

            ThrowExceptionIfValueIsNull(this.HeaderEncoding, "You must set HeaderEncoding property of MimeWriter object.");
            ThrowExceptionIfValueIsNull(mg.ContentType, "You must set ContentType property of SmtpMessage object.");

            if (mg.Contents.Count > 0 && String.IsNullOrEmpty(mg.ContentType.Boundary) == true)
            {
                mg.ContentType.Boundary = MimeWriter.GenerateBoundary();
            }
#if !NETFX_CORE
            if (this.DkimSignatureGenerator != null)
            {
                this.AddDkimSignatureHeader(mg);
            }
#endif
            foreach (var header in mg.Headers)
            {
                this.WriteHeader(stream, header.Key, header.Value);
            }
            //TO
            WriteMailAddressList(stream, "To", mg.To);
            //ReplyTo
            WriteMailAddressList(stream, "Reply-To", mg.ReplyTo);
            //Cc
            WriteMailAddressList(stream, "Cc", mg.Cc);
            //Bcc never write because blind for others

            this.WriteEncodedHeader(stream, mg.ContentType);

            stream.Write(ByteData.NewLine);

            WriteBody(stream, mg);

            stream.Write(ByteData.NewLine);
            stream.WriteByte(46);
            stream.Write(ByteData.NewLine);
        }
        private void Write(Stream stream, SmtpContent content)
        {
            var ct = content;

            ThrowExceptionIfValueIsNull(this.HeaderEncoding, "You must set HeaderEncoding property of SmtpContent object.");
            ThrowExceptionIfValueIsNull(ct.ContentDisposition, "You must set ContentDisposition property of SmtpContent object.");
            ThrowExceptionIfValueIsNull(ct.ContentType, "You must set ContentType property of SmtpContent object.");
            ThrowExceptionIfValueIsNull(ct.ContentType.CharsetEncoding, "You must set CharsetEncoding property of ContentType property of SmtpContent object.");

            foreach (var header in ct.Headers)
            {
                this.WriteHeader(stream, header.Key, header.Value);
            }

            if (ct.ContentType.IsMultipart == true && String.IsNullOrEmpty(ct.ContentType.Boundary) == true)
            {
                ct.ContentType.Boundary = MimeWriter.GenerateBoundary();
            }
            this.WriteEncodedHeader(stream, ct.ContentType);
            this.WriteEncodedHeader(stream, ct.ContentDisposition);

            stream.Write(ByteData.NewLine);

            if (ct.ContentType.IsMultipart == true)
            {
                var boundary = ct.ContentType.CharsetEncoding.GetBytes("--" + ct.ContentType.Boundary + "\r\n");
                for (int i = 0; i < ct.Contents.Count; i++)
                {
                    stream.Write(boundary);

                    Write(stream, ct.Contents[i]);
                }
                stream.Write(ct.ContentType.CharsetEncoding.GetBytes("--" + ct.ContentType.Boundary + "--\r\n"));
            }
            else
            {
                if (ct.ContentType.IsText == true && String.IsNullOrEmpty(ct.BodyText) == false)
                {
                    this.WriteEncodedBodyText(stream, ct.BodyText, ct.ContentTransferEncoding, ct.ContentType.CharsetEncoding, 74);
                }
                else if (ct.BodyData != null)
                {
                    Byte[] bb = null;
                    switch (ct.ContentTransferEncoding)
                    {
                        case TransferEncoding.Base64:
                            {
                                var converter = new Base64Converter(ct.BodyData.Length);
                                bb = converter.Encode(ct.BodyData);
                            }
                            break;
                        case TransferEncoding.QuotedPrintable:
                            {
                                var converter = new QuotedPrintableConverter(ct.BodyData.Length, QuotedPrintableConvertMode.Default);
                                bb = converter.Encode(ct.BodyData);
                            }
                            break;
                        case TransferEncoding.None:
                        case TransferEncoding.SevenBit:
                        case TransferEncoding.EightBit:
                        case TransferEncoding.Binary:
                        default: throw new InvalidOperationException();
                    }
                    stream.Write(bb, 0, bb.Length);
                    stream.Write(ByteData.NewLine);
                }
            }
        }
#if !NETFX_CORE
        public void AddDkimSignatureHeader(SmtpMessage message)
        {
            var converter = this.DkimSignatureGenerator;
            var mg = message;
            var headers = new List<SmtpMailHeader>();

            mg.Headers.Remove(DkimSignatureGenerator.SignatureKey);
            foreach (SmtpMailHeader header in mg.Headers)
            {
                headers.Add(new SmtpMailHeader(header.Key, header.Value));
            }
            //To            
            {
                var mm = new MemoryStream();
                WriteMailAddressList(mm, mg.To);
                var value = mg.ContentType.CharsetEncoding.GetString(mm.ToArray());
                headers.Add(new SmtpMailHeader("To", value));
            }
            //Cc
            {
                var mm = new MemoryStream();
                WriteMailAddressList(mm, mg.To);
                var value = mg.ContentType.CharsetEncoding.GetString(mm.ToArray());
                headers.Add(new SmtpMailHeader("Cc", value));
            }
            //Content-Type
            {
                var mm = new MemoryStream();
                WriteEncodedHeader(mm, mg.ContentType);
                var value = mg.ContentType.CharsetEncoding.GetString(mm.ToArray());
                headers.Add(new SmtpMailHeader("Content-Type", value));
            }

            {
                var mm = new MemoryStream();
                WriteBody(mm, mg);
                var bodyText = mg.ContentType.CharsetEncoding.GetString(mm.ToArray());
                var headerValue = converter.GenerateDkimHeaderValue(bodyText);
                headers.Add(new SmtpMailHeader(DkimSignatureGenerator.SignatureKey, headerValue));
                var appendHeaderValue = converter.GenerateSignature(headers);
                mg.Headers[DkimSignatureGenerator.SignatureKey] = headerValue + appendHeaderValue;
            }
        }
#endif

        internal void WriteEncodedHeader(String key, String value)
        {
            this.WriteEncodedHeader(_Stream, key, value);
        }
        private void WriteEncodedHeader(Stream stream, String key, String value)
        {
            var headerBuffer = this.HeaderEncoding.GetBytes(key);
            var maxCharCount = 74 - headerBuffer.Length;
            stream.Write(headerBuffer);
            stream.Write(ByteData.ColonSpace);// :[white space]
            WriteEncodedHeaderValue(stream, value, ByteData.NewLineTab, true, maxCharCount);
        }
        private void WriteEncodedHeader(Stream stream, ContentType header)
        {
            if (String.IsNullOrEmpty(header.Value) == true) { return; }

            var headerBuffer = GetAsciiBytes("Content-Type");
            var maxCharCount = 74 - headerBuffer.Length;
            stream.Write(headerBuffer);
            stream.Write(ByteData.ColonSpace);// :[white space]
            stream.Write(GetAsciiBytes(header.Value));
            stream.WriteByte(59);// ;
            stream.Write(ByteData.NewLine);

            if (header.CharsetEncoding != null)
            {
                stream.WriteByte(9);// Tab
                stream.Write(ByteData.Charset);
                stream.WriteByte(34);// "
                stream.Write(GetAsciiBytes(header.CharsetEncoding.WebName));
                stream.WriteByte(34);// "
                stream.WriteByte(59);// ;
                stream.Write(ByteData.NewLine);
            }

            if (String.IsNullOrEmpty(header.Boundary) == false)
            {
                stream.WriteByte(9);// Tab
                stream.Write(ByteData.Boundary);
                stream.WriteByte(34);// "
                stream.Write(GetAsciiBytes(header.Boundary));
                stream.WriteByte(34);// "
                stream.Write(ByteData.NewLine);
            }
            if (String.IsNullOrEmpty(header.Name) == false)
            {
                if (this.FileNameEncoding == Smtp.FileNameEncoding.BestEffort)
                {
                    WriteMimeParameterRfc2047EncodedValue(stream, "Name", header.Name);
                }
                else
                {
                    WriteMimeParameter(stream, "Name", header.Name);
                }
            }
            foreach (var p in header.Parameters)
            {
                WriteMimeParameter(stream, p.Key, p.Value);
            }
        }
        private void WriteEncodedHeader(Stream stream, ContentDisposition header)
        {
            if (String.IsNullOrEmpty(header.Value) == true) { return; }

            var headerBuffer = GetAsciiBytes("Content-Disposition");
            var maxCharCount = 74 - headerBuffer.Length;
            stream.Write(headerBuffer);
            stream.Write(ByteData.ColonSpace);// :[white space]
            stream.Write(GetAsciiBytes(header.Value));
            stream.WriteByte(59);// ;
            stream.Write(ByteData.NewLine);

            if (String.IsNullOrEmpty(header.FileName) == false)
            {
                if (this.FileNameEncoding == Smtp.FileNameEncoding.BestEffort)
                {
                    WriteMimeParameterRfc2231EncodedValue(stream, "FileName", header.FileName);
                }
                else
                {
                    WriteMimeParameter(stream, "FileName", header.FileName);
                }
            }
            foreach (var p in header.Parameters)
            {
                WriteMimeParameter(stream, p.Key, p.Value);
            }
        }
        private void WriteEncodedHeaderValue(Stream stream, String value, Byte[] newlineChars, Boolean appendNewLine, Int32 maxCharCount)
        {
            Stream str = stream;
            var encoding = this.HeaderEncoding;
            var text = value.ToCharArray();
            Int32 startIndex = 0;
            Int32 charCountPerRow = 0;
            Int32 ByteCount = 0;

            if (maxCharCount > MaxCharCountPerRow)
            { throw new ArgumentException("maxCharCount must less than MimeWriter.MaxCharCountPerRow."); }

            charCountPerRow = (Int32)Math.Floor((maxCharCount - (encoding.WebName.Length + 10)) * 0.75);
            for (int i = 0; i < text.Length; i++)
            {
                ByteCount = encoding.GetByteCount(text, startIndex, (i + 1) - startIndex);
                if (ByteCount > charCountPerRow)
                {
                    WriteHeader(str, encoding.GetBytes(text, startIndex, i - startIndex));
                    str.Write(ByteData.EndOfEncodedHeaderBytes);
                    str.Write(newlineChars);

                    startIndex = i;
                    charCountPerRow = (Int32)Math.Floor((MaxCharCountPerRow - (encoding.WebName.Length + 10)) * 0.75);
                }
            }
            if (startIndex < text.Length)
            {
                WriteHeader(str, encoding.GetBytes(text, startIndex, text.Length - startIndex));
                str.Write(ByteData.EndOfEncodedHeaderBytes);
            }
            if (appendNewLine == true)
            {
                str.Write(ByteData.NewLine);
            }
        }

        private void WriteHeader(Stream stream, String key, String value)
        {
            if (String.IsNullOrEmpty(value) == true) { return; }

            if (MimeWriter.AsciiCharOnly(value) == true)
            {
                this.WriteAsciiHeader(stream, key, value);
            }
            else
            {
                this.WriteEncodedHeader(stream, key, value);
            }
        }
        private void WriteAsciiHeader(Stream stream, String key, String value)
        {
            var headerBuffer = GetAsciiBytes(key);
            stream.Write(headerBuffer);
            stream.Write(ByteData.ColonSpace);// :[white space]
            stream.Write(GetAsciiBytes(value));
            stream.Write(ByteData.NewLine);
        }
        private void WriteHeaderValue(Stream stream, String value, Encoding encoding, Int32 maxCharCount)
        {
            Stream str = stream;
            var text = value.ToCharArray();
            Int32 startIndex = 0;
            Int32 charCountPerRow = maxCharCount;
            Int32 ByteCount = 0;

            if (maxCharCount > MaxCharCountPerRow)
            { throw new ArgumentException("maxCharCount must less than MimeWriter.MaxCharCountPerRow."); }

            charCountPerRow = maxCharCount;
            for (int i = 0; i < text.Length; i++)
            {
                ByteCount = (i + 1) - startIndex;
                if (ByteCount > charCountPerRow)
                {
                    str.Write(encoding.GetBytes(text, startIndex, i - startIndex));
                    str.Write(ByteData.NewLineTab);

                    startIndex = i;
                }
            }
            str.Write(encoding.GetBytes(text, startIndex, text.Length - startIndex));
            stream.Write(ByteData.NewLine);
        }

        private void WriteMimeParameter(Stream stream, String key, String value)
        {
            if (AsciiCharOnly(value) == true)
            {
                stream.WriteByte(9);// Tab
                stream.Write(GetAsciiBytes(key));
                stream.WriteByte(61);// =
                stream.WriteByte(34);// "
                stream.Write(GetAsciiBytes(value));
                stream.WriteByte(34);// "
                stream.WriteByte(59);// ;
                stream.Write(ByteData.NewLine);// \r\n
            }
            else
            {
                switch (this.MimeHeaderParameterEncoding)
                {
                    case MimeHeaderParameterEncoding.Rfc2047:
                        WriteMimeParameterRfc2047EncodedValue(stream, key, value);
                        break;
                    case MimeHeaderParameterEncoding.Rfc2231:
                        WriteMimeParameterRfc2231EncodedValue(stream, key, value);
                        break;
                    default: throw new InvalidOperationException();
                }
            }
        }
        private void WriteMimeParameterRfc2047EncodedValue(Stream stream, String key, String value)
        {
            var bb = GetAsciiBytes(key);
            stream.WriteByte(9);// Tab
            stream.Write(bb);
            stream.WriteByte(61);// =
            stream.WriteByte(34);//"
            WriteEncodedHeaderValue(stream, value, ByteData.NewLineSpace, false, MaxCharCountPerRow - bb.Length - 8);
            stream.WriteByte(34);//"
            stream.Write(ByteData.NewLine);
        }
        private void WriteMimeParameterRfc2231EncodedValue(Stream stream, String key, String value)
        {
            var encoding = this.HeaderEncoding;
            var length = value.Length;
            Byte[] buffer = new Byte[value.Length * 3];
            Int32 index = 0;

            for (int i = 0; i < length; i++)
            {
                var b = (Byte)value[i];
                //0-9
                if (0x30 <= b && b <= 0x39)
                {
                    buffer[index++] = b;
                }
                else if (0x41 <= b && b <= 0x5a)//A-Z
                {
                    buffer[index++] = b;
                }
                else if (0x61 <= b && b <= 0x7a)//a-z
                {
                    buffer[index++] = b;
                }
                else
                {
                    buffer[index++] = 0x25;// %
                    var cc = ((Byte)b).ToString("X2");
                    buffer[index++] = (Byte)cc[0];
                    buffer[index++] = (Byte)cc[1];
                }
            }
            Byte[] bb = new Byte[index];
            Buffer.BlockCopy(buffer, 0, bb, 0, index);

            Int32 startIndex = 0;
            Int32 charCountPerRow = 0;
            Int32 rowNo = 0;

            charCountPerRow = MimeWriter.MaxCharCountPerRow - key.Length - encoding.WebName.Length - 10;
            if (charCountPerRow < 20)
            {
                charCountPerRow = 20;
            }

            if (bb.Length < charCountPerRow)
            {
                //key*=encoding''value
                stream.WriteByte(9);// Tab
                stream.Write(GetAsciiBytes(key));
                stream.WriteByte(42);// *
                stream.WriteByte(61);// =
                stream.Write(GetAsciiBytes(encoding.WebName));
                stream.WriteByte(39);// '
                stream.WriteByte(39);// '
                stream.Write(bb);
                stream.Write(ByteData.NewLine);
            }
            else
            {
                while (true)
                {
                    //key*0*=encoding''value
                    stream.WriteByte(9);// Tab
                    stream.Write(GetAsciiBytes(key));
                    stream.WriteByte(42);// *
                    stream.Write(GetAsciiBytes(rowNo.ToString()));// 0
                    stream.WriteByte(42);// *
                    stream.WriteByte(61);// =
                    if (rowNo == 0)
                    {
                        stream.Write(GetAsciiBytes(encoding.WebName));
                        stream.WriteByte(39);// '
                        stream.WriteByte(39);// '
                    }
                    if (startIndex + charCountPerRow < bb.Length)
                    {
                        stream.Write(bb, startIndex, charCountPerRow);
                        stream.Write(ByteData.NewLine);
                    }
                    else
                    {
                        stream.Write(bb, startIndex, bb.Length - startIndex);
                        stream.WriteByte(59);// ;
                        stream.Write(ByteData.NewLine);
                        break;
                    }
                    rowNo += 1;
                    startIndex += charCountPerRow;
                }
            }
        }
        private void WriteHeader(Stream stream, Byte[] value)
        {
            var str = stream;
            Byte[] bb = null;

            switch (this.HeaderRfc2047Encoding)
            {
                case Rfc2047Encoding.Base64:
                    {
                        var converter = _Base64HeaderConverter;
                        bb = Encoding.UTF8.GetBytes(String.Format("=?{0}?B?", this.HeaderEncoding.WebName));
                        str.Write(bb);
                        bb = converter.Encode(value);
                        str.Write(bb);
                    }
                    break;
                case Rfc2047Encoding.QuotedPrintable:
                    {
                        var converter = _QuotedPrintableHeaderConverter;
                        bb = Encoding.UTF8.GetBytes(String.Format("=?{0}?Q?", this.HeaderEncoding.WebName));
                        str.Write(bb);
                        bb = converter.Encode(value);
                        str.Write(bb);
                    }
                    break;
                default: throw new InvalidOperationException();
            }
        }
        private void WriteMailAddressList(Stream stream, String key, List<MailAddress> mailAddressList)
        {
            if (mailAddressList.Count > 0)
            {
                stream.Write(GetAsciiBytes(key));
                stream.Write(ByteData.ColonSpace);// :[white space]

                WriteMailAddressList(stream, mailAddressList);
            }
        }
        private void WriteMailAddressList(Stream stream, List<MailAddress> mailAddressList)
        {
            Byte[] bb = null;
            var count = mailAddressList.Count;

            for (int i = 0; i < count; i++)
            {
                if (bb != null)
                {
                    stream.Write(bb);
                }
                if (mailAddressList[i].AsciiCharOnly == true)
                {
                    this.WriteHeaderValue(stream, mailAddressList[i].RawValue, Encoding.UTF8, 74);
                }
                else
                {
                    this.WriteEncodedHeaderValue(stream, mailAddressList[i].RawValue, ByteData.NewLineTab, true, 70);
                }
                if (bb == null)
                {
                    bb = new Byte[] { (Byte)'\t', (Byte)',', (Byte)' ' };
                }
            }
        }

        public void WriteBody(SmtpMessage message)
        {
            WriteBody(_Stream, message);
        }
        private void WriteBody(Stream stream, SmtpMessage message)
        {
            var mg = message;

            if (mg.IsSigned == false)
            {
                WriteBodyData(stream, mg);
            }
            else
            {
                Stream bodyStream = new MemoryStream();
                WriteBodyData(bodyStream, mg);
                var boundary = mg.ContentType.CharsetEncoding.GetBytes("--" + mg.ContentType.Boundary);
                if (mg.IsEncrypted == true)
                {
                    var signedStream = new MemoryStream();
                    this.WriteSignedData(signedStream, mg, bodyStream.ToByteArray(), boundary);
                    this.WriteEncryptedData(stream, mg, signedStream.ToByteArray());
                }
                else
                {
                    this.WriteSignedData(stream, mg, bodyStream.ToByteArray(), boundary);
                }
            }
        }
        private void WriteBodyData(Stream stream, SmtpMessage message)
        {
            var mg = message;

            if (mg.Contents.Count == 0)
            {
                throw new NotImplementedException();
            }
            else
            {
                ThrowExceptionIfValueIsNull(mg.ContentType.CharsetEncoding, "You must set CharsetEncoding property of ContentType property of SmtpMessage object.");
                
                var boundary = mg.ContentType.CharsetEncoding.GetBytes("--" + mg.ContentType.Boundary);
                for (int i = 0; i < mg.Contents.Count; i++)
                {
                    stream.Write(boundary);
                    stream.Write(ByteData.NewLine);

                    Write(stream, mg.Contents[i]);
                }
                stream.Write(mg.ContentType.CharsetEncoding.GetBytes("--" + mg.ContentType.Boundary + "--\r\n"));
            }
        }
        private void WriteEncodedBodyText(Stream stream, String value, TransferEncoding encodeType, Encoding encoding, Int32 maxCharCount)
        {
            Stream str = stream;
            Byte[] bb = null;

            if (maxCharCount > MaxCharCountPerRow)
            { throw new ArgumentException("maxCharCount must less than MimeWriter.MaxCharCountPerRow."); }

            switch (encodeType)
            {
                case TransferEncoding.None: bb = GetAsciiBytes(value); break;
                case TransferEncoding.SevenBit: bb = GetAsciiBytes(value); break;
                case TransferEncoding.EightBit: bb = encoding.GetBytes(value); break;
                case TransferEncoding.Binary: bb = Encoding.UTF8.GetBytes(value); break;
                case TransferEncoding.Base64: bb = _Base64BodyConverter.Encode(encoding.GetBytes(value)); break;
                case TransferEncoding.QuotedPrintable: bb = _QuotedPrintableBodyConverter.Encode(encoding.GetBytes(value)); break;
                default: throw new InvalidOperationException();
            }
            stream.Write(bb);
            stream.Write(ByteData.NewLine);
        }
#if NETFX_CORE
        private void WriteSignedData(Stream stream, SmtpMessage message, Byte[] body, Byte[] boundary)
        {
            var mg = message;
            Stream mm = stream;

            ThrowExceptionIfValueIsNull(mg.From.CryptographicKeyInfo.Base64Content, "Can't sign message unless the From property contains a privateKey.");

            mm.Write(ByteData.ContentTypeMultipartSignedProtocolApplicationXpkcs7Signature);
            mm.WriteByte(34);// "
            mm.Write(boundary);
            mm.WriteByte(34);// "
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.NewLine);

            mm.Write(ByteData.NewLine);
            mm.Write(boundary);
            mm.Write(ByteData.NewLine);
            mm.Write(body);
            mm.Write(ByteData.NewLine);
            mm.Write(boundary);
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.ContentTypeApplicationXpkcs7Signature);
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.ContentTransferEncodingIsBase64);
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.ContentDispositionAttachmentFileNameIsSmimeP7s);

            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.NewLine);
            var signatureBuffer = Cryptography.ToSignMessage(CryptographicBuffer.CreateFromByteArray(body), mg.From.CryptographicKeyInfo);
            Byte[] signature;
            CryptographicBuffer.CopyToByteArray(signatureBuffer, out signature);
            Base64Converter converter = new Base64Converter(body.Length);
            mm.Write(converter.Encode(signature));
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.NewLine);
            mm.Write(boundary);
            mm.Write(Encoding.UTF8.GetBytes("--"));
            mm.Write(ByteData.NewLine);
        }
        private void WriteEncryptedData(Stream stream, SmtpMessage message, Byte[] signedContent)
        {
            //Do Nothing...
        }
#else
        private void WriteSignedData(Stream stream, SmtpMessage message, Byte[] body, Byte[] boundary)
        {
            var mg = message;
            Stream mm = stream;

            ThrowExceptionIfValueIsNull(mg.From.SigningCertificate, "Can't sign message unless the From property contains a signing certificate.");

            mm.Write(ByteData.ContentTypeMultipartSignedProtocolApplicationXpkcs7Signature);
            mm.WriteByte(34);// "
            mm.Write(boundary);
            mm.WriteByte(34);// "
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.NewLine);

            byte[] signature = Cryptography.GetSignature(body, mg.From.SigningCertificate, mg.From.EncryptionCertificate);
            Base64Converter converter = new Base64Converter(signature.Length);

            mm.Write(ByteData.NewLine);
            mm.Write(boundary);
            mm.Write(ByteData.NewLine);
            mm.Write(body);
            mm.Write(ByteData.NewLine);
            mm.Write(boundary);
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.ContentTypeApplicationXpkcs7Signature);
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.ContentTransferEncodingIsBase64);
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.ContentDispositionAttachmentFileNameIsSmimeP7s);
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.NewLine);
            mm.Write(converter.Encode(signature));
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.NewLine);
            mm.Write(boundary);
            mm.Write(Encoding.UTF8.GetBytes("--"));
            mm.Write(ByteData.NewLine);
        }
        private void WriteEncryptedData(Stream stream, SmtpMessage message, Byte[] signedContent)
        {
            var mg = message;
            Stream mm = stream;
            X509Certificate2Collection encryptionCertificates = new X509Certificate2Collection();

            ThrowExceptionIfValueIsNull(mg.From.EncryptionCertificate, "To send an encryted message, the sender must have an encryption certificate specified.");
            encryptionCertificates.Add(mg.From.EncryptionCertificate);

            foreach (MailAddress address in mg.To)
            {
                ThrowExceptionIfValueIsNull(address.EncryptionCertificate, "To send an encryted message, all receivers( To, CC, and Bcc) must have an encryption certificate specified.");
                encryptionCertificates.Add(address.EncryptionCertificate);
            }

            mm.Write(ByteData.ContentTypeApplicationXpkcs7Mime);
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.ContentTransferEncodingIsBase64);
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.ContentDispositionAttachmentFileNameIsSmimeP7m);
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.NewLine);
            mm.Write(ByteData.NewLine);

            Byte[] encrypted = Cryptography.EncryptMessage(signedContent, encryptionCertificates);
            var converter = new Base64Converter(encrypted.Length);
            mm.Write(converter.Encode(encrypted));
            mm.Write(ByteData.NewLine);
        }
#endif
        public static string GenerateBoundary()
        {
            return String.Format("{0}", Guid.NewGuid().ToString("D").Replace("-", "_"));
        }
        public static String DateTimeOffsetString(DateTimeOffset dateTime)
        {
            //http://tools.ietf.org/html/rfc1123
            //instead of ddd, dd MMM yyyy HH:mm:ss +0000
            //1. dateTime.ToString("r"); timeZone -> GMT
            //2. time + timezone .ToString("hhmm")
            return dateTime.ToString("ddd, dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture) + " " + (dateTime.Offset.TotalMinutes >= 0 ? "+" : "-") + dateTime.Offset.Hours.ToString("00") + dateTime.Offset.Minutes.ToString("00");
        }
        private static Boolean AsciiCharOnly(String text)
        {
            return Encoding.UTF8.GetByteCount(text) == text.Length;
        }
        private static Byte[] GetAsciiBytes(String value)
        {
            return value.ToCharArray().Select(el => (Byte)el).ToArray();
        }
        private static void ThrowExceptionIfValueIsNull(Object value, String message)
        {
            if (value == null)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
