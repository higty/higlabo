using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigLabo.Bot.Facebook.Send
{
    public class SendMediaResponse
    {
        public String Recipient_ID { get; set; }
        public String Message_ID { get; set; }
        public String Attachment_ID { get; set; }
    }
}
