using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using HigLabo.Core;

namespace HigLabo.Bot.Facebook.Send
{
    public enum QuickReplyContentType
    {
        Text,
        Location
    }
    public class QuickReplyButton : IButton, IPayload
    {
        public QuickReplyContentType ContentType { get; set; }
        public String Title { get; set; }
        public String Payload { get; set; }
        public String ImageUrl { get; set; }

        public QuickReplyButton()
        {
        }
        public string CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"content_type\":\"").AppendJsonEncoded(this.ContentType.ToStringFromEnum().ToLower()).Append("\"");
                if (this.ContentType == QuickReplyContentType.Text)
                {
                    sb.Append(",");
                    sb.Append("\"title\":\"").AppendJsonEncoded(this.Title).Append("\",");
                    sb.Append("\"payload\":\"").AppendJsonEncoded(this.Payload).Append("\"");
                    if (this.ImageUrl.IsNullOrEmpty() == false)
                    {
                        sb.Append(",");
                        sb.Append("\"image_url\":\"").AppendJsonEncoded(this.ImageUrl).Append("\"");
                    }
                }
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
