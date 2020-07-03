using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Bot.Line.Send
{
    public class StickerMessage : ISendMessage
    {
        public MessageType Type
        {
            get
            {
                return MessageType.Sticker;
            }
        }
        public String PackageID { get; set; }
        public String StickerID { get; set; }

        public String CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"type\":\"sticker\",");
                sb.Append("\"packageID\":\"").AppendJsonEncoded(this.PackageID).Append("\",");
                sb.Append("\"stickerID\":\"").AppendJsonEncoded(this.StickerID).Append("\"");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
