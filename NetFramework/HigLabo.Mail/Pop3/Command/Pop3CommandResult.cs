using System;
using System.Collections.Generic;
using System.Text;
using HigLabo.Net.Mail;

namespace HigLabo.Net.Pop3
{
    /// <summary>Represents result of pop3 command class.
    /// </summary>
    public class Pop3CommandResult
    {
        private String _Text = "";
        private Boolean _Ok = true;
		/// <summary>
		/// 
		/// </summary>
        public String Text
        {
            get { return this._Text; }
        }
		/// <summary>
		/// 
		/// </summary>
        public Boolean Ok
        {
            get { return this._Ok; }
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
        public Pop3CommandResult(String text)
        {
            this._Ok = IsResponseOk(text);
            this._Text = text;
        }
        public static Boolean IsResponseOk(String text)
        {
            return text.StartsWith("+OK", StringComparison.OrdinalIgnoreCase);
        }
    }
}
