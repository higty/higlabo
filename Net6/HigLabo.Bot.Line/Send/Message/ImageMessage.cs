using HigLabo.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Bot.Line.Send
{
    public class ImageMessage : ISendMessage
    {
        public MessageType Type
        {
            get
            {
                return MessageType.Image;
            }
        }
        public String OriginalContentUrl { get; set; }
        public String PreviewImageUrl { get; set; }

        public String CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"type\":\"image\",");
                sb.Append("\"originalContentUrl\":\"").AppendJsonEncoded(this.OriginalContentUrl).Append("\",");
                sb.Append("\"previewImageUrl\":\"").AppendJsonEncoded(this.PreviewImageUrl).Append("\"");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
