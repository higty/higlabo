using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Bot.Line.Send
{
    public class ConfirmTemplate : ISendMessage
    {
        public String Text { get; set; }
        public List<TemplateAction> Actions { get; private set; } = new List<TemplateAction>();

        public string CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"type\":\"confirm\",");
                sb.Append("\"text\":\"").AppendJsonEncoded(this.Text).Append("\",");
                sb.Append("\"actions\":[");
                for (int i = 0; i < this.Actions.Count; i++)
                {
                    sb.Append(this.Actions[i].CreateJson());
                    if (i < this.Actions.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                sb.Append("]");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
