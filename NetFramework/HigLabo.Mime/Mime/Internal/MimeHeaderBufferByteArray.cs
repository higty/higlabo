using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using HigLabo.Converter;

namespace HigLabo.Mime.Internal
{
    internal unsafe class MimeHeaderBufferByteArray : BufferByteArray
    {
        public Boolean IsEnd { get; private set; }

        public MimeHeaderBufferByteArray()
            :base(1024)
        {
            this.IsEnd = false;
        }
        public void Add(Byte[] data, Boolean isEnd)
        {
            base.Add(data);
            this.IsEnd = isEnd;
        }
        public Boolean IsEmptyNewLine()
        {
            if (this.Length == 1)
            {
                return this.Data[0] == 10;
            }
            else if (this.Length == 2)
            {
                return this.Data[0] == 13 && this.Data[1] == 10;
            }
            return false;
        }
        public Boolean IsOkResponseLine()
        {
            var d = this.Data;

            return d[0] == (Byte)'+' &&
                (d[1] == (Byte)'O' || d[1] == (Byte)'o') &&
                (d[2] == (Byte)'K' || d[2] == (Byte)'k');
        }
    }
}
