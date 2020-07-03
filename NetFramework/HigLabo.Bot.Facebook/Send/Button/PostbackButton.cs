using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using HigLabo.Core;

namespace HigLabo.Bot.Facebook.Send
{
    public class PostbackButton : IButton, IPayload
    {
        public String Title { get; set; }
        public String Payload { get; set; }

        public PostbackButton()
        {
        }
        public string CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"type\":\"postback\",");
                sb.Append("\"title\":\"").AppendJsonEncoded(this.Title).Append("\",");
                sb.Append("\"payload\":\"").AppendJsonEncoded(this.Payload).Append("\"");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
