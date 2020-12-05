using System;
using System.Collections.Generic;
using System.Text;
using HigLabo.Net.Ftp;

namespace HigLabo.Net.Internal
{
	/// <summary>
    /// Represent context of request and response process and provide data about context.
    /// </summary>
    internal class FtpDataReceiveContext : DataReceiveContext
    {
        private enum ParseState
        {
            ResponseCode, HasNextLine, Message, CarriageReturn, LastLineMessage, LastLineCarriageReturn,
        }
        private ParseState _State = ParseState.ResponseCode;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encoding"></param>
		internal FtpDataReceiveContext(Encoding encoding):
			base(encoding)
		{
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
            Int32 responseCodeIndex = 0;

			for (int i = 0; i < size; i++)
			{
				this.Stream.WriteByte(bb[i]);
                if (_State == ParseState.ResponseCode)
                {
                    responseCodeIndex += 1;
                    if (responseCodeIndex == 3)
                    {
                        var lastByte = this.GetLastByte(3);
                        var text = this.Encoding.GetString(lastByte);
                        Int32 code = 0;
                        if (Int32.TryParse(text, out code) == true)
                        {
                            _State = ParseState.HasNextLine;
                        }
                        else
                        {
                            _State = ParseState.Message;
                        }
                    }
                }
                else if (_State == ParseState.HasNextLine)
                {
                    if (bb[i] == AsciiCharCode.Space.GetNumber())
                    {
                        _State = ParseState.LastLineMessage;
                    }
                    else if (bb[i] == AsciiCharCode.Minus.GetNumber())
                    {
                        _State = ParseState.Message;
                    }
                    else { throw new DataTransferContextException(this); }
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
                        responseCodeIndex = 0;
                        _State = ParseState.ResponseCode;
                    }
                    else { throw new DataTransferContextException(this); }
                }
                else if (_State == ParseState.LastLineMessage)
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
