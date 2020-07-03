using HigLabo.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Bot.Line.Send
{
    public class LocationMessage : ISendMessage
    {
        public MessageType Type
        {
            get
            {
                return MessageType.Location;
            }
        }
        public String Title { get; set; }
        public String Address { get; set; }
        public Decimal Latitude { get; set; }
        public Decimal Longitude { get; set; }

        public String CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"type\":\"location\",");
                sb.Append("\"title\":\"").AppendJsonEncoded(this.Title).Append("\",");
                sb.Append("\"address\":\"").AppendJsonEncoded(this.Address).Append("\",");
                sb.Append("\"latitude\":\"").AppendJsonEncoded(this.Latitude.ToString()).Append("\",");
                sb.Append("\"longitude\":\"").AppendJsonEncoded(this.Longitude.ToString()).Append("\"");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
