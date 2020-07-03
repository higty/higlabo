using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Imap
{
    public class ImapClientDefaultSettings : SocketClientDefaultSettings
    {
        public Int32 TagNo { get; set; }
        public ImapClientDefaultSettings()
        {
            this.Port = 143;
            this.TagNo = 1;
        }
    }
}
