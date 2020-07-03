using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Smtp
{
    /// Represent mail command.
    /// <summary>
    /// Represent mail command.
    /// </summary>
    public class MailCommand : SmtpCommand
    {
        private String _ReversePath = "";
		/// <summary>
		/// 
		/// </summary>
        public override String Name
        {
            get { return "Mail From:"; }
        }
		/// <summary>
		/// 
		/// </summary>
        public String ReversePath
        {
            get { return this._ReversePath; }
            set { this._ReversePath = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="reversePath"></param>
        public MailCommand(String reversePath)
        {
            this._ReversePath = reversePath;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public override String GetCommandString()
        {
            return String.Format("{0}{1}", this.Name, this.ReversePath);
        }
    }
}
