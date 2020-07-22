using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpRequestUploadingEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public Int64 Size { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public Int64 TotalSize { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="totalSize"></param>
        public HttpRequestUploadingEventArgs(Int64 size, Int64 totalSize)
        {
            this.Size = size;
            this.TotalSize = totalSize;
        }
    }
}
