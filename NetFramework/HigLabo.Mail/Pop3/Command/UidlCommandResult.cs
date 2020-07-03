using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using HigLabo.Net.Mail;

namespace HigLabo.Net.Pop3
{
    /// <summary>
    /// 
    /// </summary>
    public class UidlCommandResult
    {
        private class RegexList
        {
            public static readonly Regex MessageIndex = new Regex(@"^([0-9]+)[\s|\t]+.*$", RegexOptions.None);
            public static readonly Regex Uid = new Regex(@"^[0-9]+[\s|\t]+([\x21-\x7E]+)$", RegexOptions.None);
        }
        private Int64 _MailIndex = 0;
        private String _Uid = "";
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
        public String Uid
        {
            get { return this._Uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public UidlCommandResult(String text)
        {
            if (text == null)
            { throw new ArgumentNullException("text"); }

            this._MailIndex = UidlCommandResult.GetMessageIndex(text);
            this._Uid = UidlCommandResult.GetUid(text);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndex"></param>
        /// <param name="uid"></param>
        public UidlCommandResult(Int64 mailIndex, String uid)
        {
            this._MailIndex = mailIndex;
            this._Uid = uid;
        }
        /// 受信した行の文字列を解析し、メールのIndexを取得します。
        /// <summary>
        /// 受信した行の文字列を解析し、メールのIndexを取得します。
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static Int64 GetMessageIndex(String line)
        {
            return Int64.Parse(RegexList.MessageIndex.Replace(line.Replace("\r\n", ""), "$1"));
        }
        /// 受信した行の文字列を解析し、メールのUIDを取得します。
        /// <summary>
        /// 受信した行の文字列を解析し、メールのUIDを取得します。
        /// </summary>
        /// <param name="line"></param>
        /// <remarks>Characters in the range 0x21 to 0x7E: http://www.ietf.org/rfc/rfc1939.txt</remarks>
        /// <returns></returns>
        private static String GetUid(String line)
        {
            return RegexList.Uid.Replace(line.Replace("\r\n", ""), "$1");
        }
    }
}
