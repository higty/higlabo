using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using HigLabo.Net.Mail;

namespace HigLabo.Net.Smtp
{
    /// Represent an line of smtp command result responsed from server.
    /// <summary>
    /// Represent an line of smtp command result responsed from server.
    /// </summary>
    public class SmtpCommandResultLine
    {
		private class RegexList
		{
			public static readonly Regex SmtpResultLine = new Regex(@"(?<StatusCode>[0-9]{3})(?<HasNextLine>[\s-]{0,1})(?<Message>.*)", RegexOptions.IgnoreCase);
		}
        private Int32 _StatusCodeNumber = 0;
        private SmtpCommandResultCode _StatusCode = SmtpCommandResultCode.None;
		/// <summary>
		/// 
		/// </summary>
        public Int32 CodeNumber
        {
            get { return this._StatusCodeNumber; }
        }
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
        public Boolean HasNextLine { get; private set; }
		/// <summary>
		/// 
		/// </summary>
        public String Message { get; private set; }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="line"></param>
        public SmtpCommandResultLine(String line)
        {
            Match m = RegexList.SmtpResultLine.Match(line);
            if (Int32.TryParse(m.Groups["StatusCode"].Value, out this._StatusCodeNumber) == false)
            { throw new MailClientException("Invalid format response." + Environment.NewLine + line); }
            this._StatusCode = (SmtpCommandResultCode)this._StatusCodeNumber;
            this.HasNextLine = m.Groups["HasNextLine"].Value == "-";
            this.Message = m.Groups["Message"].Value;
        }
    }
}
