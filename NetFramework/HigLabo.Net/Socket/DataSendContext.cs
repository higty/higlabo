using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HigLabo.Net.Internal
{
	/// <summary>
    /// Represent context of request and response process and provide data about context.
    /// </summary>
    internal class DataSendContext : DataTransferContext
    {
        private Int32 _SendBufferSize = 0;
        internal Int32 SendBufferSize
        {
            get { return _SendBufferSize; }
        }
        internal Boolean DataRemained
        {
            get { return this.Stream.Position < this.Stream.Length; }
        }
        internal DataSendContext(Stream stream, Encoding encoding) :
            base(stream, encoding)
        {
            this._SendBufferSize = (Int32)this.Stream.Length;
        }
        internal void FillBuffer()
        {
            Byte[] bb = this.Buffer;

            if (this.Stream.Position + bb.Length < this.Stream.Length)
            {
                this.Stream.Read(bb, 0, bb.Length);
                _SendBufferSize = bb.Length;
            }
            else
            {
                Int32 count = (Int32)(this.Stream.Length - this.Stream.Position);
                this.Stream.Read(bb, 0, count);
                _SendBufferSize = count;
            }
        }
    }
}
