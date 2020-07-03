using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Smtp
{
    /// Represent data command.
    /// <summary>
    /// Represent data command.
    /// </summary>
    public class DataCommand : SmtpCommand
    {
		/// <summary>
		/// 
		/// </summary>
        public override String Name
        {
            get { return "Data"; }
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
