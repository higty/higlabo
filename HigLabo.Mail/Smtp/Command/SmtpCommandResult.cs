using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Smtp
{
    /// Represent smtp command result responsed from server.
    /// <summary>
    /// Represent smtp command result responsed from server.
    /// </summary>
    public class SmtpCommandResult
    {
        private SmtpCommandResultCode _StatusCode = SmtpCommandResultCode.None;
        private String _Message = "";
		/// <summary>
		/// 
		/// </summary>
        public SmtpCommandResultCode StatusCode
        {
            get { return this._StatusCode; }
        }
		/// <summary>
		/// 
		/// </summary>
        public String Message
        {
            get { return this._Message; }
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="lines"></param>
        public SmtpCommandResult(SmtpCommandResultLine[] lines)
        {
            StringBuilder sb = new StringBuilder();
            if (lines.Length == 0) { return; }

            this._StatusCode = lines[0].StatusCode;
            for (int i = 0; i < lines.Length; i++)
            {
                sb.Append(lines[i].Message);
                if (i < lines.Length - 1)
                {
                    sb.AppendLine();
                }
            }
            this._Message = sb.ToString();
        }
    }
}
