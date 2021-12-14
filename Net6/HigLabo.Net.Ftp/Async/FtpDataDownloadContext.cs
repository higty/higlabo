using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HigLabo.Net.Internal
{
    internal class FtpDataDownloadContext : DataReceiveContext
    {
        private Int32 _FileSize;
       
        public FtpDataDownloadContext(Stream stream, Encoding encoding, Int32 fileSize)
            : base(stream, encoding)
        {
            this._FileSize = fileSize;
        }
        protected override bool ParseBuffer(int size)
        {
            Byte[] bb = this.Buffer;

            this.Stream.Write(bb, 0, size);
            for (int i = 0; i < size; i++)
            {
                bb[i] = 0;
            }
            return this.ReadBytes + size < this._FileSize;
        }
    }
}
