using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Pop3
{
    /// <summary>Represents dele command.
    /// </summary>
    public class DeleCommand : Pop3Command
    {
        private Int64 _MailIndex = 1;
		/// <summary>
		/// 
		/// </summary>
        public override String Name
        {
            get { return "Dele"; }
        }
		/// <summary>
		/// 
		/// </summary>
        public Int64 MailIndex
        {
            get { return this._MailIndex; }
            set { this._MailIndex = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="mailIndex"></param>
        public DeleCommand(Int64 mailIndex)
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
            return String.Format("{0} {1}", this.Name, this._MailIndex);
        }
    }
}
