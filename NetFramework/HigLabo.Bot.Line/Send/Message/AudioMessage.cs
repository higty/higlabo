using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Bot.Line.Send
{
    public class AudioMessage : ISendMessage
    {
        public MessageType Type
        {
            get
            {
                return MessageType.Image;
            }
        }
        public String OriginalContentUrl { get; set; }
        public Int32 Duration { get; set; }

        public String CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"type\":\"audio\",");
                sb.Append("\"originalContentUrl\":\"").AppendJsonEncoded(this.OriginalContentUrl).Append("\",");
                sb.Append("\"duration\":").AppendJsonEncoded(this.Duration.ToString());
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
