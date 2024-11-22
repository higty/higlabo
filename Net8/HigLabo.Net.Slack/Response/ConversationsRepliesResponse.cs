using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack;

public partial class ConversationsRepliesResponse
{
    public Message[]? Messages { get; set; }
    public Boolean? HasMore { get; set; }

}
