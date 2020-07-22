using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
#if !NETFX_CORE
    [Serializable]
#endif
    public class SocketClientException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public SocketClientException()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public SocketClientException(String message)
            : base(message)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        public SocketClientException(Exception exception)
            : base(exception.Message, exception)
        {
        }
    }
}
