using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Pop3
{
	/// <summary>The exception that is thrown when receive response error occurs.
	/// </summary>
    public class InvalidMailMessageException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public String MailText { get; private set; }
		/// <summary>
		/// 
		/// </summary>
        public InvalidMailMessageException()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailText"></param>
        /// <param name="innerException"></param>
		public InvalidMailMessageException(String mailText, Exception innerException)
			: base(innerException.Message, innerException)
		{
            this.MailText = MailText;
		}
	}
}
