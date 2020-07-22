using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HigLabo.Converter
{
    public class Rfc2047Converter
    {
        private enum Rfc2047ParsingState
        {
            NotParsing,
            Start,
            Charset,
            BorQ,
            Value,
            ValueEnd,
            End,
        }
        private class ParseContextData
        {
            private Base64Converter _Base64Converter = null;
            private QuotedPrintableConverter _QuotedPrintableHeaderConverter = null;
            private List<Byte[]> _ByteList = new List<byte[]>();

            public Rfc2047Encoding? Encoding { get; private set; }
            public Encoding Charset { get; private set; }

            public ParseContextData(Base64Converter base64Converter, QuotedPrintableConverter quotedPrintableConverter)
            {
                _Base64Converter = base64Converter;
                _QuotedPrintableHeaderConverter = quotedPrintableConverter;
            }
            public void Add(Rfc2047Encoding encoding, Encoding charset, Byte[] value)
            {
                this.Encoding = encoding;
                this.Charset = charset;
                _ByteList.Add(value);
            }
            public String Decode()
            {
                if (this.HasData() == false) { return ""; }

                var bb = this.GetBytes();
                switch (this.Encoding)
                {
                    case Rfc2047Encoding.Base64: return this.Charset.GetString(_Base64Converter.Decode(bb)); 
                    case Rfc2047Encoding.QuotedPrintable: return this.Charset.GetString(_QuotedPrintableHeaderConverter.Decode(bb)); 
                    default: throw new InvalidOperationException();
                }
            }
            public Boolean HasData()
            {
                return _ByteList.Sum(el => el.Length) > 0;
            }
            public void Clear()
            {
                this.Encoding = null;
                this.Charset = null;
                _ByteList.Clear();
            }
            public Byte[] GetBytes()
            {
                var bb = new Byte[_ByteList.Sum(el => el.Length)];
                var index = 0;
                for (int i = 0; i < _ByteList.Count; i++)
                {
                    for (int bIndex = 0; bIndex < _ByteList[i].Length; bIndex++)
                    {
                        bb[index] = _ByteList[i][bIndex];
                        index++;
                    }
                }
                return bb;
            }
        }
        private Base64Converter _Base64Converter = null;
        private QuotedPrintableConverter _QuotedPrintableHeaderConverter = null;

        public Encoding Encoding { get; set; }

        public Rfc2047Converter()
        {
            this.Encoding = Encoding.UTF8;
            _Base64Converter = new Base64Converter(200);
            _QuotedPrintableHeaderConverter = new QuotedPrintableConverter(200, QuotedPrintableConvertMode.Header);
        }
        public unsafe String Decode(String text)
        {
            if (String.IsNullOrEmpty(text) == true) { return ""; }

            var bb = this.Encoding.GetBytes(text);
            fixed (Byte* start = bb)
            {
                var end = start + sizeof(Byte) * bb.Length;
                var s = Decode(start, end);
                return s;
            }
        }
        public unsafe String Decode(Byte* start, Byte* end)
        {
            var current = start;
            //Used for not encoded text.
            var buffer = new Byte[end - current];
            Int32 index = 0;
            Byte* rfc2047Start = null;
            Byte* rfc2047Current = null;
            Rfc2047ParsingState state = Rfc2047ParsingState.NotParsing;
            Encoding charset = null;
            Rfc2047Encoding? encoding = null;
            Int32 whiteSpaceCount = 0;
            StringBuilder sb = new StringBuilder(buffer.Length);
            var cx = new ParseContextData(_Base64Converter, _QuotedPrintableHeaderConverter);

            while (current < end)
            {
                switch (state)
                {
                    case Rfc2047ParsingState.NotParsing:
                        #region
                        if (*current == '=')
                        {
                            state = Rfc2047ParsingState.Start;
                            rfc2047Start = current;
                        }
                        break;
                        #endregion
                    case Rfc2047ParsingState.Start:
                        #region
                        if (*current == '?')
                        {
                            state = Rfc2047ParsingState.Charset;
                            rfc2047Current = current + 1;
                        }
                        else
                        {
                            state = Rfc2047ParsingState.NotParsing;
                        }
                        break;
                        #endregion
                    case Rfc2047ParsingState.Charset:
                        #region
                        if (*current == '?')
                        {
                            var bb = CreateNewBytes(new IntPtr(rfc2047Current), current - rfc2047Current);
                            charset = EncodingDictionary.Current.TryGetEncoding(this.Encoding.GetString(bb));
                            if (charset == null)
                            {
                                state = Rfc2047ParsingState.NotParsing;
                                rfc2047Current = null;
                            }
                            else
                            {
                                state = Rfc2047ParsingState.BorQ;
                                rfc2047Current = current + 1;
                            }
                        }
                        break;
                        #endregion
                    case Rfc2047ParsingState.BorQ:
                        #region
                        if (*current == '?')
                        {
                            var bb = CreateNewBytes(new IntPtr(rfc2047Current), current - rfc2047Current);
                            var BorQ = this.Encoding.GetString(bb).ToUpper();
                            if (BorQ == "B" || BorQ == "Q")
                            {
                                switch (BorQ)
                                {
                                    case "B": encoding = Rfc2047Encoding.Base64; break;
                                    case "Q": encoding = Rfc2047Encoding.QuotedPrintable; break;
                                    default: throw new InvalidOperationException();
                                }
                                state = Rfc2047ParsingState.Value;
                                rfc2047Current = current + 1;
                            }
                            else
                            {
                                state = Rfc2047ParsingState.NotParsing;
                                rfc2047Current = null;
                            }
                        }
                        break;
                        #endregion
                    case Rfc2047ParsingState.Value:
                        #region
                        if (*current == '?')
                        {
                            state = Rfc2047ParsingState.ValueEnd;
                        }
                        break;
                        #endregion
                    case Rfc2047ParsingState.ValueEnd:
                        #region
                        if (*current == '=')
                        {
                            if (index > 0)
                            {
                                sb.Append(cx.Decode());
                                cx.Clear();
                                sb.Append(this.Encoding.GetString(buffer.Take(index).ToArray()));
                                index = 0;
                            }

                            var bb = CreateNewBytes(new IntPtr(rfc2047Current), current - rfc2047Current - 1);
                            if (cx.Encoding != encoding || cx.Charset != charset)
                            {
                                sb.Append(cx.Decode());
                                cx.Clear();
                            }
                            else
                            {
                                var text = cx.Decode();
                                if (text[text.Length - 1] == '�')
                                {
                                    //Invalid encoding.Maybe encoder devide middle of 2byte char.
                                    //Concat current line and next line.
                                }
                                else
                                {
                                    sb.Append(cx.Decode());
                                    cx.Clear();
                                }
                            }
                            cx.Add(encoding.Value, charset, bb);

                            rfc2047Start = null;
                            rfc2047Current = null;
                            whiteSpaceCount = 0;
                            state = Rfc2047ParsingState.End;
                        }
                        else
                        {
                            state = Rfc2047ParsingState.NotParsing;
                        }
                        break;
                        #endregion
                    case Rfc2047ParsingState.End: state = Rfc2047ParsingState.NotParsing; break;
                    default: break;
                }

                if (state == Rfc2047ParsingState.NotParsing)
                {
                    #region Add text that is invalid format like "=?Charset?S"
                    if (rfc2047Start != null)
                    {
                        this.AddChar(buffer, ref index, whiteSpaceCount);
                        whiteSpaceCount = -1;
                        
                        var length = current - rfc2047Start;
                        for (int i = 0; i < length; i++)
                        {
                            buffer[index++] = *rfc2047Start;
                            rfc2047Start++;
                        }
                        rfc2047Start = null;
                    }
                    #endregion

                    #region
                    if (*current == (Byte)'=') { continue; }
                    if (*current == (Byte)' ')
                    {
                        if (whiteSpaceCount > -1)
                        {
                            whiteSpaceCount++;
                        }
                        else
                        {
                            buffer[index++] = (Byte)' ';
                        }
                    }
                    else if (*current != (Byte)'\r' &&
                        *current != (Byte)'\n' &&
                        *current != (Byte)'\t')
                    {
                        this.AddChar(buffer, ref index, whiteSpaceCount);
                        whiteSpaceCount = -1;

                        buffer[index++] = *current;
                    }
                    #endregion
                }
                current++;
            }
            if (cx.HasData())
            {
                sb.Append(cx.Decode());
            }
            sb.Append(this.Encoding.GetString(buffer.Take(index).ToArray()));
            return sb.ToString();
        }
        private void AddChar(Byte[] buffer, ref Int32 index, Int32 count)
        {
            for (int i = 0; i < count; i++)
            {
                buffer[index++] = (Byte)' ';
            }
        }
        internal static Byte[] CreateNewBytes(IntPtr pointer, Int64 length)
        {
            Byte[] bb = new Byte[length];
            Marshal.Copy(pointer, bb, 0, bb.Length);
            return bb;
        }
    }
}
