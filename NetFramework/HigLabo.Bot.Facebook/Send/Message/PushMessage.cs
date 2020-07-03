using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigLabo.Bot.Facebook.Send
{
    public abstract class PushMessage : ISendMessage
    {
        public String RecipientID { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public NotificationType Notification_Type { get; set; }

        public abstract String CreateJson();
    }
}
