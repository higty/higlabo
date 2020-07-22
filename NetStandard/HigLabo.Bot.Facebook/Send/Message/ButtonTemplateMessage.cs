using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Bot.Facebook.Send
{
    public class ButtonTemplateMessage : PushMessage
    {
        public String Text { get; set; }
        public List<IButton> Buttons { get; private set; } = new List<IButton>();

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
                        sb.Append("\"template_type\":\"button\",");
                        sb.Append("\"text\":\"").AppendJsonEncoded(this.Text).Append("\",");
                        sb.Append("\"buttons\":[");
                        for (int i = 0; i < this.Buttons.Count; i++)
                        {
                            sb.Append(this.Buttons[i].CreateJson());
                            if (i < this.Buttons.Count - 1)
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

        public static List<ButtonTemplateMessage> Create(String recipientID, String text, IEnumerable<IButton> buttonList)
        {
            var l = new List<ButtonTemplateMessage>();
            var tp = new ButtonTemplateMessage();
            tp.RecipientID = recipientID;
            tp.Text = text;
            foreach (var bt in buttonList)
            {
                if (tp.Buttons.Count == 3)
                {
                    l.Add(tp);
                    tp = new ButtonTemplateMessage();
                    tp.RecipientID = recipientID;
                    tp.Text = "　";
                }
                tp.Buttons.Add(bt);
            }
            if (tp.Buttons.Count > 0)
            {
                l.Add(tp);
            }
            return l;
        }
    }
}
