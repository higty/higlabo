using System;
using System.Collections.Generic;
using System.Text;
using HigLabo.Net.Mail;
using HigLabo.Mime;

namespace HigLabo.Net.Smtp
{
    /// Represent the result of sending smtp mail.
    /// <summary>
    /// Represent the result of sending smtp mail.
    /// </summary>
    public class SendMailResult
    {
        private List<MailAddress> _InvalidMailAddressList = new List<MailAddress>();
        /// <summary>
        /// 
        /// </summary>
        public Boolean SendSuccessful
        {
            get { return this.State == SendMailResultState.Success; }
        }
        /// <summary>
        /// 
        /// </summary>
        public SendMailResultState State { get; private set; }
		/// <summary>
		/// 
		/// </summary>
        public List<MailAddress> InvalidMailAddressList
        {
            get { return this._InvalidMailAddressList; }
        }
		/// <summary>
		/// 
		/// </summary>
        public SendMailCommand Command { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public String Message { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="command"></param>
        public SendMailResult(SendMailResultState state, SendMailCommand command)
        {
            this.Command = command;
            this.State = state;
            this.Message = "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="command"></param>
        /// <param name="invalidMailAddressList"></param>
        public SendMailResult(SendMailResultState state, SendMailCommand command, String message, IEnumerable<MailAddress> invalidMailAddressList)
        {
            this.Command = command;
            this.State = state;
            this.Message = message;
            this.InvalidMailAddressList.AddRange(invalidMailAddressList);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Success={0}, State={1}, InvalidMailAddressCount={2}"
                , this.SendSuccessful, this.State, this.InvalidMailAddressList.Count);
        }
    }
}
