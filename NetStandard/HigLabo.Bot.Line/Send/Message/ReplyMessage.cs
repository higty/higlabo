using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Bot.Line.Send
{
    public class ReplyMessage : ISendMessage
    {
        public String ReplyToken { get; set; }
        public List<ISendMessage> Messages { get; private set; } = new List<ISendMessage>();

        public string CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"replyToken\":\"").AppendJsonEncoded(this.ReplyToken).Append("\",");
                sb.Append("\"messages\":[");
                for (int i = 0; i < this.Messages.Count; i++)
                {
                    sb.Append(this.Messages[i].CreateJson());
                    if (i < this.Messages.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                sb.Append("]");
            }
            sb.Append("}");
            return sb.ToString();
        }
        public static List<ReplyMessage> Create(String replyToken, String text, IEnumerable<TemplateAction> actionList)
        {
            var l = new List<ReplyMessage>();

            var mg = new ReplyMessage();
            mg.ReplyToken = replyToken;
            var tp = new ButtonsTemplate();
            tp.AltText = text;
            tp.Text = text;
            mg.Messages.Add(tp);

            foreach (var bt in actionList)
            {
                if (tp.Actions.Count == 3)
                {
                    l.Add(mg);

                    mg = new ReplyMessage();
                    mg.ReplyToken = replyToken;
                    tp = new ButtonsTemplate();
                    tp.AltText = text;
                    tp.Text = "　";
                    mg.Messages.Add(tp);
                }
                tp.Actions.Add(bt);
            }
            if (tp.Actions.Count > 0)
            {
                l.Add(mg);
            }
            return l;
        }
    }
}
