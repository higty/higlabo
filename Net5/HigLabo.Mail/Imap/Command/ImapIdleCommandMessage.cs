using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Imap
{
    /// <summary>
    /// 
    /// </summary>
    public class ImapIdleCommandMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public ImapIdleCommandMessageType MessageType { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32 Number { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="number"></param>
        public ImapIdleCommandMessage(ImapIdleCommandMessageType messageType, Int32 number)
        {
            this.MessageType = messageType;
            this.Number = number;
        }
    }
}
