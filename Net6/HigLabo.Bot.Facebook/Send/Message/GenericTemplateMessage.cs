using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Bot.Facebook.Send
{
    public class GenericTemplateMessage : PushMessage
    {
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
                        sb.Append("\"template_type\":\"generic\",");
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
