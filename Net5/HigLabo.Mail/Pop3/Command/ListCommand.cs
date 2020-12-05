using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using HigLabo.Net.Mail;

namespace HigLabo.Net.Pop3
{
    /// <summary>Represents list command.
    /// </summary>
    public class ListCommand : Pop3Command
    {
        private Int64? _MailIndex = null;
		/// <summary>
		/// 
		/// </summary>
        public override String Name
        {
            get { return "List"; }
        }
		/// <summary>
		/// 
		/// </summary>
        public Int64? MailIndex
        {
            get { return this._MailIndex; }
            set { this._MailIndex = value; }
        }
		/// <summary>
		/// 
		/// </summary>
        public ListCommand()
        {
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="mailIndex"></param>
        public ListCommand(Int64 mailIndex)
        {
            if (mailIndex < 1)
            { throw new ArgumentException(); }
            this._MailIndex = mailIndex;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public override String GetCommandString()
        {
			if (_MailIndex.HasValue == true)
			{
				return String.Format("{0} {1}", this.Name, this._MailIndex);
			}
			return this.Name;
        }
    }
}
