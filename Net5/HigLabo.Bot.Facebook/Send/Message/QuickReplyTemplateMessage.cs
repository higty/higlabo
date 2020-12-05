using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Bot.Facebook.Send
{
    public class QuickReplyTemplateMessage : PushMessage
    {
        public String Text { get; set; }
        public List<QuickReplyButton> QuickReplies { get; private set; } = new List<QuickReplyButton>();

        public override String CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"recipient\":{\"id\":\"").AppendJsonEncoded(this.RecipientID).Append("\"},");
                sb.Append("\"message\":{");
                {
                    sb.Append("\"text\":\"").AppendJsonEncoded(this.Text).Append("\",");
                    sb.Append("\"quick_replies\":[");
                    for (int i = 0; i < this.QuickReplies.Count; i++)
                    {
                        sb.Append(this.QuickReplies[i].CreateJson());
                        if (i < this.QuickReplies.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.Append("]");
                }
                sb.Append("}");//message
            }
            sb.Append("}");

            return sb.ToString();
        }

        public static List<QuickReplyTemplateMessage> Create(String recipientID, String text, IEnumerable<QuickReplyButton> buttonList)
        {
            var l = new List<QuickReplyTemplateMessage>();
            var tp = new QuickReplyTemplateMessage();
            tp.RecipientID = recipientID;
            tp.Text = text;
            foreach (var bt in buttonList)
            {
                if (tp.QuickReplies.Count == 11)
                {
                    l.Add(tp);
                    tp = new QuickReplyTemplateMessage();
                    tp.RecipientID = recipientID;
                    tp.Text = "　";
                }
                tp.QuickReplies.Add(bt);
            }
            if (tp.QuickReplies.Count > 0)
            {
                l.Add(tp);
            }
            return l;
        }
    }
}
