using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Internal
{
    public class PipeStreamContext : DataReceiveContext
    {
        private enum ParseState
        {
            StartCharOfLine, Message, CarriageReturn, LineFeed, Period, LastLineCarriageReturn,
        }
        private ParseState _State = ParseState.StartCharOfLine;
        
        private new PipeStream Stream
        {
            get { return base.Stream as PipeStream; }
        }
        public PipeStreamContext(PipeStream stream, Encoding encoding)
            : base(stream, encoding)
        {
        }
        protected override Boolean ParseBuffer(Int32 size)
        {
            Byte[] bb = this.Buffer;
            MemoryStream mm = new MemoryStream();
            Boolean result = true;

            for (int i = 0; i < size; i++)
            {
                mm.WriteByte(bb[i]);
                if (_State == ParseState.StartCharOfLine)
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
                        _State = ParseState.StartCharOfLine;
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
                        result = false;
                    }
                    else { throw new DataTransferContextException(this); }
                }
                bb[i] = 0;
            }

            var data = mm.ToArray();
            this.Stream.Write(data, 0, data.Length);
            
            return result;
        }
        public void Flush()
        {
            this.Stream.Flush();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="context"></param>
        //protected PipeStreamContext BeginGetResponseStream(PipeStream stream)
        //{
        //    if (this.Socket == null)
        //    {
        //        throw new SocketClientException("Connection is closed");
        //    }
        //    var cx = new PipeStreamContext(stream, this.ResponseEncoding);
        //    var bb = cx.Buffer;
        //    this.Stream.BeginRead(bb, 0, bb.Length, this.BeginGetResponseCallback, cx);
        //    return cx;
        //}
        //protected void BeginGetResponseCallback(IAsyncResult result)
        //{
        //    PipeStreamContext cx = null;

        //    try
        //    {
        //        cx = (PipeStreamContext)result.AsyncState;
        //        if (this.Socket == null)
        //        {
        //            throw new SocketClientException("Connection is closed");
        //        }
        //        Int32 size = Stream.EndRead(result);
        //        TimeSpan ts = DateTime.Now - cx.StartTime;

        //        if (ts.TotalMilliseconds > this.ReceiveTimeout)
        //        {
        //            cx.Timeout = true;
        //            cx.Flush();
        //        }
        //        if (cx.ReadBuffer(size) == true)
        //        {
        //            var bb = cx.Buffer;
        //            this.Stream.BeginRead(bb, 0, bb.Length, this.BeginGetResponseCallback, cx);
        //        }
        //        else
        //        {
        //            cx.Flush();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        cx.Exception = ex;
        //    }
        //}

    }
}
