using System;
using System.Collections.Generic;
using System.Text;
using HigLabo.Net.Mail;
using System.IO;

namespace HigLabo.Net.Internal
{
    /// <summary>
    /// Represent context of request and response process and provide data about context.
    /// </summary>
    internal class Pop3DataReceiveContext : DataReceiveContext
    {
        private enum ParseState
        {
            StartCharOfLine, Message, CarriageReturn, LineFeed, Period, LastLineCarriageReturn,
        }
        private ParseState _State = ParseState.StartCharOfLine;
        private Boolean _IsMultiLine = false;
        internal Pop3DataReceiveContext(Encoding encoding, Boolean isMultiLine) :
            base(encoding)
        {
            _IsMultiLine = isMultiLine;
        }
        internal Pop3DataReceiveContext(Stream stream, Encoding encoding, Boolean isMultiLine) :
            base(stream, encoding)
        {
            _IsMultiLine = isMultiLine;
        }
        internal Pop3DataReceiveContext(Encoding encoding, Boolean isMultiLine, Action<String> callbackFunction) :
            base(encoding)
        {
        }
        internal Pop3DataReceiveContext(Stream stream, Encoding encoding, Boolean isMultiLine, Action<String> callbackFunction) :
            base(stream, encoding)
        {
            _IsMultiLine = isMultiLine;
			this.EndGetResponse = callbackFunction;
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

			for (int i = 0; i < size; i++)
			{
				this.Stream.WriteByte(bb[i]);
                if (_State == ParseState.StartCharOfLine)
                {
                    if (_IsMultiLine == true)
                    {
                        if (bb[i] == AsciiCharCode.Period.GetNumber())
                        {
                            _State = ParseState.Period;
                        }
                        else if (bb[i] == AsciiCharCode.CarriageReturn.GetNumber())
                        {
                            _State = ParseState.CarriageReturn;
                        }
                        else
                        {
                            _State = ParseState.Message;
                        }
                    }
                    else
                    {
                        _State = ParseState.Message;
                    }
                }
                else if (_State == ParseState.Message)
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
                        if (_IsMultiLine == true)
                        {
                            _State = ParseState.StartCharOfLine;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else { throw new DataTransferContextException(this); }
                }
                else if (_State == ParseState.Period)
                {
                    if (bb[i] == AsciiCharCode.CarriageReturn.GetNumber())
                    {
                        _State = ParseState.LastLineCarriageReturn;
                    }
                    else if (bb[i] == AsciiCharCode.Period.GetNumber())
                    {
                        _State = ParseState.Message;
                    }
                    else { throw new DataTransferContextException(this); }
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
