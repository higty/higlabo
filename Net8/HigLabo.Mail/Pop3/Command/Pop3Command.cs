using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using HigLabo.Net.Mail;

namespace HigLabo.Net.Pop3
{
    /// <summary>Represents and define behavior of pop3 command as abstract class.
	/// </summary>
    public abstract class Pop3Command
    {
		/// <summary>
		/// 
		/// </summary>
        public abstract String Name { get;}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public abstract String GetCommandString();
	}
}
