using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Ftp
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class FtpClientException : Exception
    {
        public FtpCommandResult Result { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public FtpClientException()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public FtpClientException(FtpCommandResult result)
        {
            this.Result = result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public FtpClientException(String message)
            : base(message)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        public FtpClientException(Exception exception)
            : base(exception.Message, exception)
        {
        }
    }
}
