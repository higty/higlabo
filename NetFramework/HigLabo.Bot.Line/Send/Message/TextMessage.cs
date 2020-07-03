using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Bot.Line.Send
{
    public class TextMessage : ISendMessage
    {
        public MessageType Type
        {
            get
            {
                return MessageType.Text;
            }
        }
        public String Text { get; set; }

        public String CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"type\":\"text\",");
                sb.Append("\"text\":\"").AppendJsonEncoded(this.Text).Append("\"");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
