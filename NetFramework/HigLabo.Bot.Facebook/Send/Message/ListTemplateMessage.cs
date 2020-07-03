using HigLabo.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Bot.Facebook.Send
{
    public enum TopElementStyle
    {
        Large,
        Compact,
    }
    public class ListTemplateMessage : PushMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public TopElementStyle TopElementStyle { get; set; }
        public List<Element> Elements { get; private set; } = new List<Element>();

        public override String CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"recipient\":{\"id\":\"").AppendJsonEncoded(this.RecipientID).Append("\"},");
                sb.Append("\"message\":{\"attachment\":{");
                {
                    sb.Append("\"type\":\"template\",");
                    sb.Append("\"payload\":{");
                    {
                        sb.Append("\"template_type\":\"list\",");
                        sb.Append("\"top_element_style\":\"").Append(this.TopElementStyle.ToStringFromEnum().ToLower()).Append("\",");
                        sb.Append("\"elements\":[");
                        for (int i = 0; i < this.Elements.Count; i++)
                        {
                            sb.Append(this.Elements[i].CreateJson());
                            if (i < this.Elements.Count - 1)
                            {
                                sb.Append(",");
                            }
                        }
                        sb.Append("]");
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
