using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Smtp
{
    /// Represent rcpt command.
    /// <summary>
    /// Represent rcpt command.
    /// </summary>
    public class RcptCommand : SmtpCommand
    {
        private String _ForwardPath = "";
		/// <summary>
		/// 
		/// </summary>
        public override String Name
        {
            get { return "Rcpt To:"; }
        }
		/// <summary>
		/// 
		/// </summary>
        public String ForwardPath
        {
            get { return this._ForwardPath; }
            set { this._ForwardPath = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="inForwardPath"></param>
        public RcptCommand(String inForwardPath)
        {
            this._ForwardPath = inForwardPath;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public override String GetCommandString()
        {
            return String.Format("{0}{1}", this.Name, this.ForwardPath);
        }
    }
}
