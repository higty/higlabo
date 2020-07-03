using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Pop3
{
    /// <summary>Represents top command.
    /// </summary>
    public class TopCommand : Pop3Command
    {
        private Int64 _MailIndex = 1;
        private Int32 _LineCount = 0;
		/// <summary>
		/// 
		/// </summary>
        public override String Name
        {
            get { return "Top"; }
        }
		/// <summary>
		/// 
		/// </summary>
        public Int64 MailIndex
        {
            get { return this._MailIndex; }
        }
		/// <summary>
		/// 
		/// </summary>
        public Int32 LineCount
        {
            get { return this._LineCount; }
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="mailIndex"></param>
        public TopCommand(Int64 mailIndex)
        {
            if (mailIndex < 1)
            { throw new ArgumentException(); }
            this._MailIndex = mailIndex;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="mailIndex"></param>
		/// <param name="lineCount"></param>
        public TopCommand(Int64 mailIndex, Int32 lineCount)
        {
            if (mailIndex < 1)
            { throw new ArgumentException(); }
            this._MailIndex = mailIndex;
            this._LineCount = lineCount;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public override String GetCommandString()
        {
            return String.Format("{0} {1} {2}", this.Name, this._MailIndex, this._LineCount);
        }
    }
}
