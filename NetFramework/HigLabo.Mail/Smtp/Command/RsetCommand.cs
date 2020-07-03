using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Smtp
{
    /// Represent reset command.
    /// <summary>
    /// Represent reset command.
    /// </summary>
    public class RsetCommand : SmtpCommand
    {
		/// <summary>
		/// 
		/// </summary>
        public override String Name
        {
            get { return "Rset"; }
        }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public override String GetCommandString()
        {
            return this.Name;
        }
    }
}
