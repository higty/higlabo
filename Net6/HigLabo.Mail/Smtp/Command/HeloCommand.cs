using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Smtp
{
    /// Represent helo command.
    /// <summary>
    /// Represent helo command.
    /// </summary>
    public class HeloCommand : SmtpCommand
    {
        private String _Domain = "";
		/// <summary>
		/// 
		/// </summary>
        public override String Name
        {
            get { return "Helo"; }
        }
		/// <summary>
		/// 
		/// </summary>
        public String Domain
        {
            get { return this._Domain; }
            set { this._Domain = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="domain"></param>
        public HeloCommand(String domain)
        {
            this._Domain = domain;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public override String GetCommandString()
        {
            return String.Format("{0} {1}", this.Name, this.Domain);
        }
    }
}
