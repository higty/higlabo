using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HigLabo.Net.Ftp
{
    /// Represent an line of ftp command result responsed from server.
    /// <summary>
    /// Represent an line of ftp command result responsed from server.
    /// </summary>
    public class FtpCommandResultLine
    {
		private class RegexList
		{
            public static readonly Regex FtpResultLine = new Regex(@"(?<StatusCode>[0-9]{3})(?<HasNextLine>[\s-]{0,1})(?<Message>.*)", RegexOptions.IgnoreCase);
        }
        private Int32 _CodeNumber = 0;
        private FtpCommandResultCode _StatusCode = FtpCommandResultCode.None;
        /// <summary>
        /// 
        /// </summary>
        public String Text { get; private set; }
        /// <summary>
		/// 
		/// </summary>
        public Boolean FirstLine { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public Boolean LastLine { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32 CodeNumber
        {
            get { return this._CodeNumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public FtpCommandResultCode StatusCode
        {
            get { return this._StatusCode; }
        }
        /// <summary>
		/// 
		/// </summary>
        public String Message { get; private set; }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="line"></param>
        public FtpCommandResultLine(String line)
        {
            Match m = RegexList.FtpResultLine.Match(line);

            if (m.Success == false) { throw new FtpClientException("Invalid format response." + line); }

            this.Text = line;

            Int32.TryParse(m.Groups["StatusCode"].Value, out this._CodeNumber);
            this._StatusCode = (FtpCommandResultCode)this.CodeNumber;

            this.FirstLine = true;
            this.LastLine = m.Groups["HasNextLine"].Value == " ";
            this.Message = m.Groups["Message"].Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="line"></param>
        public FtpCommandResultLine(FtpCommandResultCode code, String line)
        {
            Match m = RegexList.FtpResultLine.Match(line);

            this.Text = line;
            this._StatusCode = code;
            this._CodeNumber = (Int32)code;

            if (m.Success == true)
            {
                this.FirstLine = false;
                this.LastLine = m.Groups["HasNextLine"].Value == " ";
                this.Message = m.Groups["Message"].Value;
            }
            else
            {
                this.Message = line;
            }
        }
    }
}
