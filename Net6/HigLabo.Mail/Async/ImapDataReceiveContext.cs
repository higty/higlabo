using System;
using System.Collections.Generic;
using System.Text;
using HigLabo.Net.Mail;
using HigLabo.Net.Imap;

namespace HigLabo.Net.Internal
{
    /// <summary>
    /// Represent context of request and response process and provide data about context.
    /// </summary>
    public class ImapDataReceiveContext : DataReceiveContext
    {
        private enum ParseState
        {
            TagValidating, MultiLine, CarriageReturn, LastLine, LastLineCarriageReturn, 
        }
        private Byte[] _TagBytes = null;
        private ParseState _State = ParseState.TagValidating;
        private Action<String> _EndGetResponseCallback = null;
        /// <summary>
        /// 
        /// </summary>
        public Boolean IsFetchCommand { get; set; }
        internal ImapDataReceiveContext(String tag, Encoding encoding) :
            base(encoding)
        {
            _TagBytes = this.Encoding.GetBytes(tag);
            this.IsFetchCommand = false;
        }
        internal ImapDataReceiveContext(String tag, Encoding encoding, Action<String> callbackFunction) :
            base(encoding)
        {
            _TagBytes = this.Encoding.GetBytes(tag);
            _EndGetResponseCallback = callbackFunction;
            this.IsFetchCommand = false;
        }
        /// <summary>
        /// Read buffer data to Data property and initialize buffer.
        /// If response has next data,return true.
        /// </summary>
        /// <param name="size"></param>
        /// <returns>If response has next data,return true</returns>
        protected override Boolean ParseBuffer(Int32 size)
        {
            Byte[] bb = this.Buffer;
            Int32 tagIndex = 0;

            for (int i = 0; i < size; i++)
            {
                this.Stream.WriteByte(bb[i]);
                if (_State == ParseState.TagValidating)
                {
                    if (bb[i] == _TagBytes[tagIndex])
                    {
                        tagIndex = tagIndex + 1;
                        if (_TagBytes.Length == tagIndex)
                        {
                            _State = ParseState.LastLine;
                        }
                    }
                    else
                    {
                        _State = ParseState.MultiLine;
                    }
                }
                else if (_State == ParseState.MultiLine)
                {
                    if (bb[i] == AsciiCharCode.CarriageReturn.GetNumber())
                    {
                        _State = ParseState.CarriageReturn;
                    }
                }
                else if (_State == ParseState.CarriageReturn)
                {
                    if (bb[i] == AsciiCharCode.LineFeed.GetNumber())
                    {
                        tagIndex = 0;
                        _State = ParseState.TagValidating;
                    }
                    else if (bb[i] == AsciiCharCode.CarriageReturn.GetNumber())
                    {
                        _State = ParseState.CarriageReturn;
                    }
                    else
                    {
                        tagIndex = 0;
                        _State = ParseState.TagValidating;
                    }
                }
                else if (_State == ParseState.LastLine)
                {
                    if (bb[i] == AsciiCharCode.CarriageReturn.GetNumber())
                    {
                        _State = ParseState.LastLineCarriageReturn;
                    }
                }
                else if (_State == ParseState.LastLineCarriageReturn)
                {
                    if (bb[i] == AsciiCharCode.LineFeed.GetNumber())
                    {
                        return false;
                    }
                    else { throw new DataTransferContextException(this); }
                }
                bb[i] = 0;
            }
            return true;
        }
    }
}
