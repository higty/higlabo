using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using HigLabo.Mime.Internal;
using HigLabo.Converter;

namespace HigLabo.Mime
{
    public unsafe sealed class MimeParser
    {
        private enum MimeContentParserState
        {
            Boundary,
            Header,
            Body,
            ChildContent,
        }
        public static readonly MimeParserDefaultSettings Default = new MimeParserDefaultSettings();

        private Stream _Stream = null;
        private MimeHeaderBufferByteArray _HeaderBuffer = new MimeHeaderBufferByteArray();
        private Byte[] _Buffer = null;
        private Byte* _BufferPtr = null;
        private readonly List<Byte[]> _RawData = new List<byte[]>();

        private Rfc2047Converter _Rfc2047Converter = new Rfc2047Converter();
        private Rfc2231Converter _Rfc2231Converter = new Rfc2231Converter();
        private Base64Converter _Base64Converter = new Base64Converter(Default.Base64ConverterBufferSize);
        private QuotedPrintableConverter _QuotedPrintableBodyConverter = new QuotedPrintableConverter(Default.QuotedPrintableConverterBufferSize, QuotedPrintableConvertMode.Default);

        public Int32 BufferSize { get; set; }
        public MimeParserFilter Filter { get; private set; }
        public Encoding Encoding { get; set; }
        public Int32 Base64ConverterBufferSize
        {
            get { return _Base64Converter.BufferSize; }
            set { _Base64Converter.BufferSize = value; }
        }
        public Int32 QuotedPrintableConverterBufferSize
        {
            get { return _QuotedPrintableBodyConverter.BufferSize; }
            set { _QuotedPrintableBodyConverter.BufferSize = value; }
        }

        public MimeParser()
            : this(Default.Encoding, Default.BufferSize)
        {
        }
        public MimeParser(Int32 bufferSize)
            : this(Default.Encoding, bufferSize)
        {
        }
        public MimeParser(Encoding encoding, Int32 bufferSize)
        {
            this.BufferSize = bufferSize;
            this.Encoding = encoding;
            this.Filter = Default.Filter.Copy();
        }

        private Byte[] GetBuffer()
        {
            if (_Buffer == null || _Buffer.Length != this.BufferSize)
            {
                _Buffer = new Byte[this.BufferSize];
            }
            return _Buffer;
        }
        private void Setup(Stream stream)
        {
            this._Stream = stream;
            _RawData.Clear();
        }
        private void AddToRawData(Byte[] data)
        {
            if (this.Filter.LoadMessageRawData == false) return;
            _RawData.Add(data);
        }
        private void AddToRawDataWithNewline(Byte[] data)
        {
            if (this.Filter.LoadMessageRawData == false) return;
            if (data.Length == 0) return;
            _RawData.Add(data);
            _RawData.Add(new Byte[] { 13, 10 });
        }

        public MimeMessage ToMimeMessage(String text)
        {
            return ToMimeMessage(new MemoryStream(this.Encoding.GetBytes(text)));
        }
        public MailMessage ToMailMessage(String text)
        {
            return ToMailMessage(new MemoryStream(this.Encoding.GetBytes(text)));
        }
        public MimeMessage ToMimeMessage(Stream stream)
        {
            return Parse(stream, new MimeMessage());
        }
        public MailMessage ToMailMessage(Stream stream)
        {
            return Parse(stream, new MailMessage());
        }
     
        private unsafe T Parse<T>(Stream stream, T message)
            where T: MimeMessage
        {
            T mg = message;
            this.Setup(stream);

            try
            {
                fixed (byte* bufferPtr = this.GetBuffer())
                {
                    _BufferPtr = bufferPtr;
                    var cx = new MimeStreamBuffer();
                    this.ReadHeaderAndMessageBody(mg, cx);
                    if (this.Filter.LoadContents == true &&
                        String.IsNullOrEmpty(mg.ContentType.Boundary) == false)
                    {
                        var boundary = this.CreateBoundary("--" + mg.ContentType.Boundary);
                        var content = this.ReadMimeContent(cx, boundary);
                        mg.Contents.AddRange(content);
                    }
                }
            }
            catch (InvalidMimeFormatException ex)
            {
                throw new InvalidMimeMessageException(mg, ex.ParseText);
            }
            finally
            {
                _BufferPtr = null;
            }

            if (this.Filter.LoadMessageRawData == true)
            {
                mg.RawData = _RawData.SelectMany(el => el).ToArray();
            }
            _RawData.Clear();

            return mg;
        }
        private String GetRawText(Stream stream)
        {
            Int64? nowPosition = null;

            if (stream.CanSeek == true)
            {
                nowPosition = stream.Position;
                stream.Position = 0;
            }
            var target = new MemoryStream();
            var bb = new Byte[stream.Length];
            stream.Read(bb, 0, bb.Length);
            target.Write(bb, 0, bb.Length);

            if (nowPosition.HasValue == true)
            {
                stream.Position = nowPosition.Value;
            }
            return this.Encoding.GetString(target.ToArray());
        }
        private void ReadFromStream(MimeStreamBuffer context)
        {
            var buffer = this.GetBuffer();
            var stream = _Stream;
            var lastLineLength = 0;
            var lastLine = context.GetLastLine();

            if (lastLine != null)
            {
                lastLineLength = lastLine.Length;
            }
            var filledLength = buffer.Length - lastLineLength - 1;
            if (stream.Position + filledLength > stream.Length)
            {
                filledLength = (Int32)(stream.Length - stream.Position);
            }
            var readLength = stream.Read(buffer, 0, filledLength);
            if (lastLineLength > 0)
            {
                Buffer.BlockCopy(buffer, 0, buffer, lastLineLength, readLength);
                Buffer.BlockCopy(lastLine, 0, buffer, 0, lastLineLength);
            }
            buffer[lastLineLength + readLength] = 10;
            context.Initialize(_BufferPtr, lastLineLength + readLength, readLength == 0);
        }

        private unsafe void ReadHeaderAndMessageBody(MimeMessage message, MimeStreamBuffer context)
        {
            MimeHeaderBufferByteArray headerPointer = _HeaderBuffer;
            var bodyBuffer = new MimeContentByteArray();
            Boolean endOfHeader = false;
            Boolean endOfBody = false;
            Byte[] boundary = null;
            var boundaryResult = CheckBoundaryResult.None;
            var isEndOfBody = false;
            var firstLine = true;
            var cx = context;

            headerPointer.Clear();
            while (true)
            {
                this.ReadFromStream(cx);

                while (true)
                {
                    if (endOfHeader == false)
                    {
                        #region Header
                        headerPointer = cx.ReadHeader(headerPointer);
                        if (headerPointer.IsEnd == false) { break; }
                        if (firstLine == true && headerPointer.IsOkResponseLine() == true)
                        {
                            firstLine = false;
                            headerPointer.Clear();
                            continue;
                        }
                        firstLine = false;
                        var l = Encoding.UTF8.GetString(headerPointer.ToArray());
                        if (endOfHeader == false && headerPointer.IsEmptyNewLine() == true)
                        {
                            this.AddToRawData(headerPointer.ToArray());
                            headerPointer.Clear();
                            endOfHeader = true;

                            if (String.IsNullOrEmpty(message.ContentType.Boundary) == false && boundary == null)
                            {
                                boundary = CreateBoundary("--" + message.ContentType.Boundary);
                            }
                            continue;
                        }
                        if (headerPointer.IsEnd == true)
                        {
                            //New MimeHeader
                            var bb = headerPointer.ToArray();
                            this.AddToRawData(bb);

                            var header = ParseHeader(headerPointer);
                            message.Headers.Add(header);
                            headerPointer.Clear();
                        }
                        #endregion
                    }
                    else
                    {
                        #region Body
                        Byte[] bodyLine = null;
                        bodyLine = cx.ReadBody(boundary, out boundaryResult, out isEndOfBody);
                        bodyBuffer.AddBodyLine(bodyLine);
                        if (boundaryResult != CheckBoundaryResult.None || isEndOfBody == true)
                        {
                            endOfBody = true;
                            var bb = bodyBuffer.GetBodyArray();
                            if (bb.Length == 0) { break; }
                            message.TextBeforeMimeContent = this.Encoding.GetString(bb);
                            this.AddToRawDataWithNewline(bb);
                            if (message.ContentType.IsText == false) { break; }

                            this.SetMimeMessageBodyText(message, bb);
                            break;
                        }
                        #endregion
                    }
                    if (cx.IsEnd() == true || cx.EndOfStream == true) { break; }
                }
                if (endOfBody == true || cx.EndOfStream == true) { break; }
            }
        }
       
        public unsafe MimeHeader ParseHeader(Byte[] data)
        {
            var header = new MimeHeaderBufferByteArray();
            header.Add(data, true);
            return ParseHeader(header);
        }
        private unsafe MimeHeader ParseHeader(MimeHeaderBufferByteArray headerPointer)
        {
            MimeHeader header = null;

            fixed (Byte* headerPtr = headerPointer.Data)
            {
                Byte* current = headerPtr;
                Byte* end = headerPtr + headerPointer.Length * sizeof(Byte);

                while (*current == (Byte)' ')
                {
                    current++;
                }
                Byte* start = current;
                while (*current != (Byte)':')
                {
                    current++;
                    if (current == end)
                    {
                        var line = Encoding.UTF8.GetString(headerPointer.ToArray());
                        throw new InvalidMimeFormatException(line);
                    }
                }
                String key = this.Encoding.GetString(CreateNewBytes(new IntPtr(start), current - start));
                switch (key.ToLower())
                {
                    case "content-type": header = new ContentType(); break;
                    case "content-disposition": header = new ContentDisposition(); break;
                    default: header = new MimeHeader(); break;
                }
                header.Key = key;

                current++;

                while (*current == (Byte)' ')
                {
                    current++;
                }
                header.RawValue = this.Encoding.GetString(CreateNewBytes(new IntPtr(current), end - current));

                if (header.HasParameter == false)
                {
                    header.Value = _Rfc2047Converter.Decode(current, end);
                }
                header.RawData = headerPointer.ToArray();
                ParseContentType(header as ContentType);
                ParseContentDisposition(header as ContentDisposition);
            }

            return header;
        }

        internal void ParseContentType(ContentType header)
        {
            if (header == null) { return; }

            this.ParseMimeHeaderParameter(header);

            if (header.Parameters.Count == 0) { throw new InvalidMimeFormatException(header.GetRawText()); }
            header.Value = header.Parameters[0].Value;

            header.Boundary = header.GetParameterValue("boundary");
            header.Charset = header.GetParameterValue("charset");
            header.FormatFlowed = String.Equals(header.GetParameterValue("format"), "flowed", StringComparison.OrdinalIgnoreCase);
            header.DeleteSpace = String.Equals(header.GetParameterValue("delsp"), "yes", StringComparison.OrdinalIgnoreCase);
            if (String.IsNullOrEmpty(header.Charset) == false)
            {
                header.CharsetEncoding = EncodingDictionary.Current.TryGetEncoding(header.Charset);
                if (header.CharsetEncoding == null) { throw new InvalidMimeFormatException(header.GetRawText()); }
            }

            var slashIndex = header.Value.IndexOf("/", StringComparison.OrdinalIgnoreCase);
            if (slashIndex > -1)
            {
                header.MainValue = header.Value.Substring(0, slashIndex);
                slashIndex += 1;
                header.SubValue = header.Value.Substring(slashIndex, header.Value.Length - slashIndex);
            }
            header.Name = _Rfc2047Converter.Decode(header.GetParameterValue("name"));
        }
        private void ParseContentDisposition(ContentDisposition header)
        {
            if (header == null) { return; }

            this.ParseMimeHeaderParameter(header);

            if (header.Parameters.Count == 0) { throw new InvalidMimeFormatException(header.GetRawText()); }
            header.Value = header.Parameters[0].Value;
            header.FileName = _Rfc2047Converter.Decode(header.GetParameterValue("filename"));
        }
        private void ParseMimeHeaderParameter(MimeHeaderWithParameter header)
        {
            Int32 length = header.RawValue.Length;
            Int32 startIndex = 0;
            List<MimeHeaderParameter> pp = new List<MimeHeaderParameter>();
            Char previousChar = Char.MinValue;
            var insideDoubleQuatation = false;

            for (int i = 0; i < length; i++)
            {
                if (i > 0) { previousChar = header.RawValue[i - 1]; }
                var c = header.RawValue[i];
                if (previousChar == '=' && c == '"')//attribute=";
                {
                    insideDoubleQuatation = true;
                }
                if ((insideDoubleQuatation == false && c == ';') || //attribute=value;
                    (insideDoubleQuatation == true && previousChar == '"' && c == ';') || // attribute="value";
                    c == '\n' || c == '\r' || c == '\t' || i == length - 1)
                {
                    if (i - startIndex > 1)
                    {
                        var rawValue = header.RawValue.Substring(startIndex, i - startIndex);
                        var p = this.CreateMimeHeaderParameter(rawValue);
                        header.Parameters.Add(p);
                        if (p.Rfc2231Ordinal.HasValue == true)
                        {
                            pp.Add(p);
                        }
                    }
                    startIndex = i + 1;
                    insideDoubleQuatation = false;
                }
            }
            if (pp.Count > 0)
            {
                this.SetMimeHeaderParameterValue(pp);
            }
        }
        private MimeHeaderParameter CreateMimeHeaderParameter(String rawText)
        {
            MimeHeaderParameter p = new MimeHeaderParameter();

            var rawValue = rawText.Trim();
            var indexOfEqual = rawValue.IndexOf("=", StringComparison.OrdinalIgnoreCase);
            if (indexOfEqual <= 0)
            {
                p.RawText = rawText;
                p.RawValue = rawValue;
                p.Value = rawValue;
            }
            else if (indexOfEqual > -1)
            {               
                Int32? startIndexOfOrdinal = null;
                Int32? lastIndexOfOrdinal = null;

                p.RawText = rawValue;
                p.RawValue = rawValue.Substring(indexOfEqual + 1, p.RawText.Length - (indexOfEqual + 1));
                //filename*=value
                //filename*0=value
                //filename*0*=value
                for (int i = indexOfEqual - 1; i > 0; i--)
                {
                    var c = (Byte)p.RawText[i];
                    if (i == indexOfEqual - 1 && c == 42)//*
                    {
                        p.IsEncoded = true;
                        continue;
                    }
                    else if (c >= 48 && c <= 57)//0-9
                    {
                        if (lastIndexOfOrdinal.HasValue == false)
                        {
                            lastIndexOfOrdinal = i;
                        }
                        startIndexOfOrdinal = i;
                        continue;
                    }
                    
                    if (lastIndexOfOrdinal.HasValue == true && c != 42)//*
                    {
                        startIndexOfOrdinal = null;
                        lastIndexOfOrdinal = null;
                    }
                    break;
                }

                if (startIndexOfOrdinal.HasValue == true)
                {
                    p.Rfc2231Ordinal = Int32.Parse(p.RawText.Substring(startIndexOfOrdinal.Value, lastIndexOfOrdinal.Value + 1 - startIndexOfOrdinal.Value));
                    p.Key = p.RawText.Substring(0, startIndexOfOrdinal.Value - 1);
                    p.Value = p.RawValue;
                }
                else
                {
                    if (p.IsEncoded == true)
                    {
                        p.Key = p.RawText.Substring(0, indexOfEqual - 1);
                        p.Value = _Rfc2231Converter.Decode(p.RawValue);
                    }
                    else
                    {
                        p.Key = p.RawText.Substring(0, indexOfEqual);
                        p.Value = p.RawValue;
                    }
                }
                if (p.Value.StartsWith("\"") && p.Value.EndsWith("\""))
                {
                    p.Value = p.Value.Trim('"');
                }
            }
            return p;
        }
        private void SetMimeHeaderParameterValue(List<MimeHeaderParameter> parameters)
        {
            var l = parameters;

            var keyList = l.GroupBy(el => el.Key).Select(el => el.Key);
            foreach (var key in keyList)
            {
                var pp = l.FindAll(el => el.Key == key).OrderBy(el => el.Rfc2231Ordinal.Value).ToList();
                StringBuilder sb = new StringBuilder();
                StringBuilder result = new StringBuilder();

                for (int i = 0; i < pp.Count; i++)
                {
                    var p = pp[i];
                    if (p.IsEncoded == true)
                    {
                        sb.Append(p.RawValue);
                        if (i == pp.Count - 1 || pp[i + 1].IsEncoded == false)
                        {
                            result.Append(_Rfc2231Converter.Decode(sb.ToString()));
                            sb.Length = 0;
                        }
                    }
                    else
                    {
                        result.Append(p.RawValue);
                    }
                }
                for (int i = 0; i < pp.Count; i++)
                {
                    pp[i].Value = result.ToString();
                }
            }
        }
      
        private void SetMimeMessageBodyText(MimeMessage message, Byte[] bytes)
        {
            String text = "";
            String rawText = "";
            Byte[] bb = null;

            switch (message.ContentTransferEncoding)
            {
                case TransferEncoding.None: 
                case TransferEncoding.SevenBit:
                case TransferEncoding.EightBit:
                    {
                        rawText = this.Encoding.GetString(bytes);
                        bb = bytes;
                    }
                    break;
                case TransferEncoding.Base64:
                    {
                        rawText = this.Encoding.GetString(bytes);
                        bb = _Base64Converter.Decode(bytes);
                    }
                    break;
                case TransferEncoding.QuotedPrintable:
                    {
                        rawText = this.Encoding.GetString(bytes);
                        bb = _QuotedPrintableBodyConverter.Decode(bytes);
                    }
                    break;
                default: throw new InvalidOperationException();
            }
            if (message.ContentType.CharsetEncoding == null)
            {
                text = rawText;
            }
            else
            {
                text = message.ContentType.CharsetEncoding.GetString(bb);
            }
            
            if (message.ContentType.IsHtml == true)
            {
                message.BodyRawHtml = rawText;
                message.BodyHtml = text;
            }
            else
            {
                message.BodyRawText = rawText;
                message.BodyText = text;
            }
        }

        private List<MimeContent> ReadMimeContent(MimeStreamBuffer context, Byte[] boundary)
        {
            List<MimeContent> l = new List<MimeContent>();
            MimeContent mc = null;
            MimeHeaderBufferByteArray headerPointer = _HeaderBuffer;
            var bodyBuffer = new MimeContentByteArray();
            var state = MimeContentParserState.Boundary;
            var boundaryResult = CheckBoundaryResult.None;
            var isEndOfBody = false;
            Byte[] childBoundary = null;
            Byte[] line = null;
            MimeStreamBuffer cx = context;

            mc = new MimeContent();
            headerPointer.Clear();
            while (true)
            {
                if (context == null)
                {
                    this.ReadFromStream(cx);
                }
                context = null;

                while (true)
                {
                    switch (state)
                    {
                        case MimeContentParserState.Boundary:
                            #region
                            {
                                line = cx.ReadLine();
                                if (line.Length == 0) { continue; }
                                this.AddToRawData(line);
                                if (line.Length == 2 && line[0] == 13 && line[1] == 10) { continue; }

                                bodyBuffer.AddBoundaryLine(line);
                                if (IsEndByNewLine(line) == true)
                                {
                                    boundaryResult = bodyBuffer.CheckBoundary(boundary);
                                    switch (boundaryResult)
                                    {
                                        case CheckBoundaryResult.None:
                                            {
                                                var lineText = this.Encoding.GetString(line);
                                                throw new InvalidMimeFormatException(lineText);
                                            }
                                        case CheckBoundaryResult.Boundary:
                                            {
                                                headerPointer.Clear();
                                                state = MimeContentParserState.Header;
                                            }
                                            break;
                                        case CheckBoundaryResult.EndBoundary: break;
                                        default: throw new InvalidOperationException();
                                    }
                                }
                            }
                            break;
                            #endregion
                        case MimeContentParserState.Header:
                            #region
                            {
                                headerPointer = cx.ReadHeader(headerPointer);
                                if (headerPointer.IsEmptyNewLine() == true)
                                {
                                    var bb = headerPointer.ToArray();
                                    this.AddToRawData(bb);
                                    bodyBuffer.AddHeaderLine(bb);
                                    bodyBuffer.HeaderLength = bodyBuffer.Length;
                                    headerPointer.Clear();

                                    if (mc.ContentType != null && String.IsNullOrEmpty(mc.ContentType.Boundary) == false)
                                    {
                                        childBoundary = CreateBoundary("--" + mc.ContentType.Boundary);
                                        state = MimeContentParserState.ChildContent;
                                    }
                                    else
                                    {
                                        state = MimeContentParserState.Body;
                                    }
                                }
                                else if (headerPointer.IsEnd == true)
                                {
                                    var bb = headerPointer.ToArray();
                                    this.AddToRawData(bb);
                                    //New MimeHeader
                                    var header = ParseHeader(headerPointer);
                                    mc.Headers.Add(header);
                                    headerPointer.Clear();
                                    bodyBuffer.AddHeaderLine(bb);
                                }
                            }
                            break;
                            #endregion
                        case MimeContentParserState.Body:
                            #region
                            {
                                var bodyLine = cx.ReadBody(boundary, out boundaryResult, out isEndOfBody);
                                bodyBuffer.AddBodyLine(bodyLine);
                                if (boundaryResult != CheckBoundaryResult.None || isEndOfBody == true)
                                {
                                    this.SetMimeContentBody(mc, bodyBuffer);
                                    l.Add(mc);

                                    headerPointer.Clear();
                                    bodyBuffer.Clear();
                                    mc = new MimeContent();

                                    state = MimeContentParserState.Boundary;
                                }
                            }
                            break;
                            #endregion
                        case MimeContentParserState.ChildContent:
                            #region
                            {
                                var bodyLine = cx.ReadBody(childBoundary, out boundaryResult, out isEndOfBody);
                                bodyBuffer.AddBodyLine(bodyLine);
                                if (boundaryResult != CheckBoundaryResult.None || isEndOfBody == true)
                                {
                                    if (bodyBuffer.Length > 0)
                                    {
                                        this.AddToRawDataWithNewline(bodyBuffer.GetBodyArray());
                                    }

                                    mc.Contents.AddRange(ReadMimeContent(cx, childBoundary));

                                    bodyBuffer.Clear();

                                    state = MimeContentParserState.Body;
                                }
                            }
                            break;
                            #endregion
                        default: throw new InvalidOperationException();
                    }
                    if (cx.IsEnd() == true) { break; }
                    if (isEndOfBody == true || boundaryResult == CheckBoundaryResult.EndBoundary) { break; }
                }
                if (isEndOfBody == true || boundaryResult == CheckBoundaryResult.EndBoundary || cx.EndOfStream == true) { break; }
            }
            if (boundaryResult == CheckBoundaryResult.EndBoundary)
            {
                this.AddToRawData(boundary);
                this.AddToRawData(new Byte[] { 45, 45 });
            }
            return l;
        }
        private void SetMimeContentBody(MimeContent content, MimeContentByteArray bodyBuffer)
        {
            var mc = content;

            if (this.Filter.LoadContentRawData == true)
            {
                mc.RawData = bodyBuffer.GetEntireArray();
            }
            if (this.Filter.LoadContentBodyData == false) { return; }           

            var bodyBytes = bodyBuffer.GetBodyArray();
            this.AddToRawDataWithNewline(bodyBytes);
            
            if (mc.ContentType.IsText == true)
            {
                mc.BodyRawText = this.Encoding.GetString(bodyBytes);
                mc.BodyData = bodyBytes;

                var charSet = mc.ContentType.CharsetEncoding;
                if (charSet == null) { return; }

                switch (mc.ContentTransferEncoding)
                {
                    case TransferEncoding.None:
                    case TransferEncoding.SevenBit: mc.BodyText = charSet.GetString(bodyBytes); break;
                    case TransferEncoding.Base64: mc.BodyText = charSet.GetString(_Base64Converter.Decode(bodyBytes)); break;
                    case TransferEncoding.QuotedPrintable: mc.BodyText = charSet.GetString(_QuotedPrintableBodyConverter.Decode(bodyBytes)); break;
                    case TransferEncoding.EightBit: mc.BodyText = charSet.GetString(bodyBytes); break;
                    default: throw new InvalidOperationException();
                }
            }
            mc.BodyData = bodyBytes;

            if (mc.ContentType.IsRfc822)
            {
                var mg = this.Parse<MailMessage>(new MemoryStream(mc.BodyData), new MailMessage());
                mc.MailMessage = mg;
            }
        }
        private Byte[] CreateBoundary(String value)
        {
            Byte[] bb = new Byte[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                bb[i] = Convert.ToByte(value[i]);
            }
            return bb;
        }

        internal static Byte[] CreateNewBytes(IntPtr pointer, Int64 length)
        {
            Byte[] bb = new Byte[length];
            Marshal.Copy(pointer, bb, 0, bb.Length);
            return bb;
        }
        private Boolean IsEndByNewLine(Byte[] bytes)
        {
            if (bytes.Length == 0) { return false; }
            return bytes[bytes.Length - 1] == '\n';
        }
    }
}
