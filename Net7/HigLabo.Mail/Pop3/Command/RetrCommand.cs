using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Pop3
{
    /// <summary>Represents retr command.
    /// </summary>
    public class RetrCommand : Pop3Command
    {
        private Int64 _MailIndex = 1;
		/// <summary>
		/// 
		/// </summary>
        public override String Name
        {
            get { return "Retr"; }
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
        public RetrCommand(Int64 mailIndex)
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
