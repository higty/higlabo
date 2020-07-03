using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
#if !SILVERLIGHT && !NETFX_CORE && !Pcl
    [Serializable]
#endif
    public class AsyncHttpCallErrorEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public AsyncHttpContext AsyncHttpContext { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public Exception Exception { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        public AsyncHttpCallErrorEventArgs(AsyncHttpContext context, Exception ex)
        {
            this.AsyncHttpContext = context;
            this.Exception = ex;
        }
    }
}
