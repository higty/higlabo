using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HigLabo.Bot.Facebook.Send
{
    public enum AttachmentType
    {
        Audio,
        File,
        Image,
        Video,
    }
    public class AttachmentMessage : PushMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public AttachmentType AttachmentType { get; set; }
        public String Url { get; set; }
        public Boolean? IsReusable { get; set; } 
        public String AttachmentID { get; set; }

        public AttachmentMessage()
        {
            this.IsReusable = true;
        }

        public override String CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"recipient\":{\"id\":\"").AppendJsonEncoded(this.RecipientID).Append("\"},");
                sb.Append("\"message\":{\"attachment\":{");
                {
                    sb.Append("\"type\":\"").Append(this.AttachmentType.ToStringFromEnum().ToLower()).Append("\",");
                    sb.Append("\"payload\":{");
                    {
                        if (this.AttachmentID.IsNullOrEmpty())
                        {
                            sb.Append("\"url\":\"").AppendJsonEncoded(this.Url).Append("\"");
                            if (this.IsReusable.HasValue)
                            {
                                sb.Append(",\"is_reusable\":").Append(this.IsReusable.ToString().ToLower()).Append("");
                            }
                        }
                        else
                        {
                            sb.Append("\"attachment_id\":\"").AppendJsonEncoded(this.AttachmentID).Append("\"");
                        }
                    }
                    sb.Append("}");//payload
                }
                sb.Append("}");//attachment
                sb.Append("}");//message
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
