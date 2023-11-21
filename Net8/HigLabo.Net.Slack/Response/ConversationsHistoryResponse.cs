using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public partial class ConversationsHistoryResponse : RestApiResponse
    {
        public List<Message> Messages { get; init; } = new();
        public Boolean? HasMore { get; set; }
        public Int32? Pin_Count { get; set; }
    }
}
