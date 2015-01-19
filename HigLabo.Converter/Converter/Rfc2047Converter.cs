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
            NotPasing,
            Start,
            Charset,
            BorQ,
            Value,
            ValueEnd,
            End,
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
            var buffer = new Byte[end - current];
            Int32 index = 0;
            Byte* rfc2047Start = null;
            Byte* rfc2047Current = null;
            Rfc2047ParsingState state = Rfc2047ParsingState.NotPasing;
            Encoding charset = null;
            Rfc2047Encoding? encoding = null;
            Int32 whiteSpaceCount = 0;
            StringBuilder sb = new StringBuilder(buffer.Length);

            while (current < end)
            {
                switch (state)
                {
                    case Rfc2047ParsingState.NotPasing:
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
                            state = Rfc2047ParsingState.NotPasing;
                        }
                        break;
                        #endregion
                    case Rfc2047ParsingState.Charset:
                        #region
                        if (*current == '?')
                        {
                            var bb = CreateNewBytes(new IntPtr(rfc2047Current), current - rfc2047Current);
                            charset = EncodingDictionary.Current.GetEncoding(this.Encoding.GetString(bb));
                            if (charset == null)
                            {
                                state = Rfc2047ParsingState.NotPasing;
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
                                state = Rfc2047ParsingState.NotPasing;
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
                            sb.Append(this.Encoding.GetString(buffer.Take(index).ToArray()));
                            index = 0;

                            var bb = CreateNewBytes(new IntPtr(rfc2047Current), current - rfc2047Current - 1);
                            switch (encoding)
                            {
                                case Rfc2047Encoding.Base64: sb.Append(charset.GetString(_Base64Converter.Decode(bb))); break;
                                case Rfc2047Encoding.QuotedPrintable: sb.Append(charset.GetString(_QuotedPrintableHeaderConverter.Decode(bb))); break;
                                default: throw new InvalidOperationException();
                            }
                            rfc2047Start = null;
                            rfc2047Current = null;
                            whiteSpaceCount = 0;
                            state = Rfc2047ParsingState.End;
                        }
                        else
                        {
                            state = Rfc2047ParsingState.NotPasing;
                        }
                        break;
                        #endregion
                    case Rfc2047ParsingState.End: state = Rfc2047ParsingState.NotPasing; break;
                    default: break;
                }

                if (state == Rfc2047ParsingState.NotPasing)
                {
                    #region Add text that is invalid format like "=?Charset?S"
                    if (rfc2047Start != null)
                    {
                        this.AddChar(buffer, (Byte)' ', ref index, whiteSpaceCount);
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
                        this.AddChar(buffer, (Byte)' ', ref index, whiteSpaceCount);
                        whiteSpaceCount = -1;

                        buffer[index++] = *current;
                    }
                    #endregion
                }
                current++;
            }
            sb.Append(this.Encoding.GetString(buffer.Take(index).ToArray()));
            return sb.ToString();
        }
        private void AddChar(Byte[] buffer, Int32 charCode, ref Int32 index, Int32 count)
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
