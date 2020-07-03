using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HigLabo.Net.Pop3
{
    /// <summary>Represents result of stat command.
    /// </summary>
    public class StatCommandResult : Pop3CommandResult
    {
        private class RegexList
        {
            public static readonly Regex TotalMessageCount = new Regex(@"^.*\+OK[\s|\t]+([0-9]+)[\s|\t]+.*$");
            public static readonly Regex TotalSize = new Regex(@"^.*\+OK[\s|\t]+[0-9]+[\s|\t]+([0-9]+).*$");
        }
        private Int64 _TotalMessageCount = 0;
        private Int64 _TotalSize = 0;
        /// <summary>
        /// 
        /// </summary>
        public Int64 TotalMessageCount
        {
            get { return this._TotalMessageCount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int64 TotalSize
        {
            get { return this._TotalSize; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public StatCommandResult(String text)
            : base(text)
        {
            if (this.Ok == true)
            {
                this._TotalMessageCount = StatCommandResult.GetTotalMessageCount(text);
                this._TotalSize = StatCommandResult.GetTotalSize(text);
            }
        }
        /// <summary>Analyze response single line and get total mail count of mailbox.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static Int64 GetTotalMessageCount(String text)
        {
            return Int64.Parse(RegexList.TotalMessageCount.Replace(text.Replace("\r\n", ""), "$1"));
        }
        /// <summary>Analyze response single line and get total mail size of mailbox.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static Int64 GetTotalSize(String text)
        {
            return Int64.Parse(RegexList.TotalSize.Replace(text.Replace("\r\n", ""), "$1"));
        }
    }
}
