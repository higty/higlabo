using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Net.Ftp
{
    /// Represent ftp command result responsed from server.
    /// <summary>
    /// Represent ftp command result responsed from server.
    /// </summary>
    public class FtpCommandResult
    {
        private FtpCommandResultCode _StatusCode = FtpCommandResultCode.None;
		/// <summary>
		/// 
		/// </summary>
        public FtpCommandResultCode StatusCode
        {
            get { return this._StatusCode; }
            protected set { this._StatusCode = value; }
        }
		/// <summary>
		/// 
		/// </summary>
        public String Text { get; protected set; }

        protected FtpCommandResult()
        {
        }
        public FtpCommandResult(String text)
            : this(new[] { new FtpCommandResultLine(text) })
        {
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="lines"></param>
        public FtpCommandResult(FtpCommandResultLine[] lines)
        {
            StringBuilder sb = new StringBuilder();
            if (lines.Length == 0)
            { throw new ArgumentException("line must not be zero length."); }

            this._StatusCode = lines[0].StatusCode;
            for (int i = 0; i < lines.Length; i++)
            {
                sb.Append(lines[i].Text);
                if (i < lines.Length - 1)
                {
                    sb.AppendLine();
                }
            }
            this.Text = sb.ToString();
        }
        public override string ToString()
        {
            return this.Text;
        }
    }
}
