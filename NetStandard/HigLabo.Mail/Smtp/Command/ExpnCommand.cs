using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Smtp
{
    /// Represent expn command.
    /// <summary>
    /// Represent expn command.
    /// </summary>
    public class ExpnCommand : SmtpCommand
    {
        private String _MailingList = "";
		/// <summary>
		/// 
		/// </summary>
        public override String Name
        {
            get { return "Expn"; }
        }
		/// <summary>
		/// 
		/// </summary>
        public String MailingList
        {
            get { return this._MailingList; }
            set { this._MailingList = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="inMailingList"></param>
        public ExpnCommand(String inMailingList)
        {
            this._MailingList = inMailingList;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public override String GetCommandString()
        {
            return String.Format("{0} {1}", this.Name, this.MailingList);
        }
    }
}
