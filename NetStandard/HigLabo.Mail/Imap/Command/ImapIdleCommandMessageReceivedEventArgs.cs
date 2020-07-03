using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace HigLabo.Net.Imap
{
    /// <summary>
    /// 
    /// </summary>
    public class ImapIdleCommandMessageReceivedEventArgs : EventArgs
    {
        private class RegexList
        {
            public static readonly Regex Message = new Regex("\\* (?<Number>[0-9]*) (?<Type>(EXISTS)|(EXPUNGE))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }
        private List<ImapIdleCommandMessage> _MessageList = new List<ImapIdleCommandMessage>();
        /// <summary>
        /// 
        /// </summary>
        public Boolean Done { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String Text { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ImapIdleCommandMessage> MessageList
        {
            get { return _MessageList; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public ImapIdleCommandMessageReceivedEventArgs(String text)
        {
            Match m = null;
            ImapIdleCommandMessageType tp = ImapIdleCommandMessageType.Exists;

            this.Done = false;
            this.Text = text;

            StringReader sr = new StringReader(text);
            while (sr.Peek() > -1)
            {
                var line = sr.ReadLine();
                if (line.StartsWith("+ idling", StringComparison.OrdinalIgnoreCase) == true)
                {
                    _MessageList.Add(new ImapIdleCommandMessage(ImapIdleCommandMessageType.Idling, -1));
                }
                else
                {
                    m = RegexList.Message.Match(line);
                    if (String.IsNullOrEmpty(m.Value) == true) { continue; }
                    switch (m.Groups["Type"].Value)
                    {
                        case "EXISTS": tp = ImapIdleCommandMessageType.Exists; break;
                        case "EXPUNGE": tp = ImapIdleCommandMessageType.Expunge; break;
                        default: continue;
                    }
                    _MessageList.Add(new ImapIdleCommandMessage(tp, Int32.Parse(m.Groups["Number"].Value)));
                }
            }
        }
    }
}
