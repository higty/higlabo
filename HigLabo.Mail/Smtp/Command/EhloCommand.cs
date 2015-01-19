using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Smtp
{
    /// Represent ehlo command.
    /// <summary>
    /// Represent ehlo command.
    /// </summary>
    public class EhloCommand : SmtpCommand
    {
        private String _Domain = "";
		/// <summary>
		/// 
		/// </summary>
        public override String Name
        {
            get { return "Ehlo"; }
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
        public EhloCommand(String domain)
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
		/// <summary>
		/// 
		/// </summary>
        public class Result
        {
            private String _Keyword = "";
            private List<String> _Parameters = new List<string>();
			/// <summary>
			/// 
			/// </summary>
            public String Keyword
            {
                get { return this._Keyword; }
                set { this._Keyword = value; }
            }
			/// <summary>
			/// 
			/// </summary>
            public List<String> Parameters
            {
                get { return this._Parameters; }
            }
			/// <summary>
			/// 
			/// </summary>
            public Result()
            {
            }
        }
    }
}
