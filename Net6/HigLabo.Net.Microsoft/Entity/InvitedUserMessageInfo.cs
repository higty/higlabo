using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Microsoft
{
    public class InvitedUserMessageInfo
    {
        public Recipient[] CcRecipients { get; set; }
        public string CustomizedMessageBody { get; set; }
        public string MessageLanguage { get; set; }
    }
}
