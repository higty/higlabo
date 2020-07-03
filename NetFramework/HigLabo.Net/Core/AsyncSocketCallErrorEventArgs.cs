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
    public class AsyncSocketCallErrorEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public Exception Exception { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public AsyncSocketCallErrorEventArgs(Exception ex)
        {
            this.Exception = ex;
        }
    }
}
