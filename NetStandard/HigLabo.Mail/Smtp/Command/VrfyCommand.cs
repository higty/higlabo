using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Smtp
{
    /// Represent vrfy command.
    /// <summary>
    /// Represent vrfy command.
    /// </summary>
    public class VrfyCommand : SmtpCommand
    {
        private String _UserName = "";
		/// <summary>
		/// 
		/// </summary>
        public override String Name
        {
            get { return "Vrfy"; }
        }
		/// <summary>
		/// 
		/// </summary>
        public String UserName
        {
            get { return this._UserName; }
            set { this._UserName = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="userName"></param>
        public VrfyCommand(String userName)
        {
            this._UserName = userName;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public override String GetCommandString()
        {
            return String.Format("{0} {1}", this.Name, this.UserName);
        }
    }
}
