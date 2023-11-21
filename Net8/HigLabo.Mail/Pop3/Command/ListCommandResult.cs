using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using HigLabo.Net.Mail;

namespace HigLabo.Net.Pop3
{
    /// <summary>Represents result of list command.
    /// </summary>
    public class ListCommandResult
    {
        private class RegexList
        {
            public static readonly Regex MessageIndex = new Regex(@"^([0-9]+)[\s|\t]+.*$");
            public static readonly Regex Size = new Regex(@"^[0-9]+[\s|\t]+([0-9]+).*$");
        }
        private Int64 _MailIndex = 0;
        private Int32 _Size = 0;
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
        public Int32 Size
        {
            get { return this._Size; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public ListCommandResult(String text)
        {
            this._MailIndex = ListCommandResult.GetMessageIndex(text);
            this._Size = ListCommandResult.GetSize(text);
        }
        /// <summary>Analyze response single line and get mail index.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static Int64 GetMessageIndex(String line)
        {
            return Int64.Parse(RegexList.MessageIndex.Replace(line.Replace("\r\n", ""), "$1"));
        }
        /// <summary>Analyze response single line and get mail size.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static Int32 GetSize(String line)
        {
            return Int32.Parse(RegexList.Size.Replace(line.Replace("\r\n", ""), "$1"));
        }
    }
}
