using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Smtp
{
    /// Represent help command.
    /// <summary>
    /// Represent help command.
    /// </summary>
    public class HelpCommand : SmtpCommand
    {
        private String _CommandName = "";
		/// <summary>
		/// 
		/// </summary>
        public override String Name
        {
            get { return "Help"; }
        }
		/// <summary>
		/// 
		/// </summary>
        public String CommandName
        {
            get { return this._CommandName; }
            set { this._CommandName = value; }
        }
		/// <summary>
		/// 
		/// </summary>
        public HelpCommand()
        {
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="commandName"></param>
        public HelpCommand(String commandName)
        {
            this._CommandName = commandName;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public override String GetCommandString()
        {
            return String.Format("{0} {1}", this.Name, this.CommandName);
        }
    }
}
