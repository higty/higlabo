using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Bot.Line.Send
{
    public enum ActionType
    {
        Message,
        Postback,
        Url
    }
    public class TemplateAction : ISendMessage
    {
        public ActionType Type { get; set; }
        public String Label { get; set; }

        public String Text { get; set; }
        public String Data { get; set; }
        public String Url { get; set; }

        public TemplateAction() { }
        public TemplateAction(ActionType actionType, String label)
        {
            this.Type = actionType;
            this.Label = label;
        }

        public string CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"type\":\"").AppendJsonEncoded(this.Type.ToStringFromEnum().ToLower()).Append("\",");
                sb.Append("\"label\":\"").AppendJsonEncoded(this.Label).Append("\",");
                switch (this.Type)
                {
                    case ActionType.Message:
                        sb.Append("\"text\":\"").AppendJsonEncoded(this.Text).Append("\"");
                        break;
                    case ActionType.Postback:
                        sb.Append("\"data\":\"").AppendJsonEncoded(this.Data).Append("\"");
                        break;
                    case ActionType.Url:
                        sb.Append("\"url\":\"").AppendJsonEncoded(this.Url).Append("\"");
                        break;
                    default:
                        break;
                }
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
