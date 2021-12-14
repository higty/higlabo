using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Bot.Facebook.Send
{
    public class TextMessage : PushMessage
    {
        public String Text { get; set; }

        public override String CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"recipient\":{\"id\":\"").AppendJsonEncoded(this.RecipientID).Append("\"},");
                sb.Append("\"message\":{\"text\":\"").AppendJsonEncoded(this.Text).Append("\"}");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
