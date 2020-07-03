using System;
using System.Text.RegularExpressions;
using HigLabo.Net.Mail;

namespace HigLabo.Net.Imap
{
    /// <summary>Represents result of Imap command class.
    /// </summary>
    public class ImapCommandResult
    {
        private String _Text = "";
        private ImapCommandResultStatus _Status = ImapCommandResultStatus.None;
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
        public ImapCommandResultStatus Status
        {
            get { return this._Status; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="text"></param>
        public ImapCommandResult(String tag, String text)
        {
            this._Text = text;
            var rx = new Regex(@"^" + tag + " (OK|NO|BAD) .*$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Match m = rx.Match(text);
            String response = m.Groups[1].Value;
            if (String.Equals(response, "OK", StringComparison.OrdinalIgnoreCase) == true)
            {
                this._Status = ImapCommandResultStatus.Ok;
            }
            else if (String.Equals(response, "NO", StringComparison.OrdinalIgnoreCase) == true)
            {
                this._Status = ImapCommandResultStatus.No;
            }
            else if (String.Equals(response, "BAD", StringComparison.OrdinalIgnoreCase) == true)
            {
                this._Status = ImapCommandResultStatus.Bad;
            }
            else
            {
                this._Status = ImapCommandResultStatus.None;
            }
            this._Text = text;
        }
    }
}
