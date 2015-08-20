using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HigLabo.Core;

namespace HigLabo.Net.Internal
{
    /// <summary>
    /// 
    /// </summary>
    public class DataReceiveContext : DataTransferContext
    {
        private Action<String> _EndGetResponse = null;
        private Int32 _ReadCount = 0;

        public Int32 ReadBytes { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        protected Action<String> EndGetResponse
        {
            get { return _EndGetResponse; }
            set { _EndGetResponse = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encoding"></param>
        public DataReceiveContext(Encoding encoding)
            : base(new MemoryStream(), encoding)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="encoding"></param>
        public DataReceiveContext(Stream stream, Encoding encoding)
            : base(stream, encoding)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Boolean ReadBuffer(Int32 size)
        {
            if (size == 0) { return false; }
            var bl = this.ParseBuffer(size);
            this.ReadBytes += size;
            this._ReadCount += 1;
            if (this._ReadCount > 1000000) { throw new SocketClientException("Too much read count.Perhaps parser could not parse correctly."); }
            return bl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        protected virtual Boolean ParseBuffer(Int32 size)
        {
            Byte[] bb = this.Buffer;

            this.Stream.Write(bb, 0, size);
            for (int i = 0; i < size; i++)
            {
                bb[i] = 0;
            }
            if (size < bb.Length)
            {
                return false;   
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected Byte[] GetLastByte(Int32 size)
        {
            this.Stream.Position = this.Stream.Length - size;
            return this.Stream.ToByteArray();
        }
        /// <summary>
        /// 
        /// </summary>
        internal protected void OnEndGetResponse()
        {
            var eh = _EndGetResponse;
            if (eh != null)
            {
                eh(this.GetText());
            }
        }
    }
}
