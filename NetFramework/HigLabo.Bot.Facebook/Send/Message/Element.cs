using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Bot.Facebook.Send
{
    public class Element : ISendMessage
    {
        public String Title { get; set; }
        public String ImageUrl { get; set; }
        public String SubTitle { get; set; }
        public DefaultAction DefaultAction { get; set; }
        public List<IButton> Buttons { get; private set; } = new List<IButton>();

        public string CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"title\":\"").AppendJsonEncoded(this.Title).Append("\",");
                sb.Append("\"image_url\":\"").AppendJsonEncoded(this.ImageUrl).Append("\",");
                sb.Append("\"subtitle\":\"").AppendJsonEncoded(this.SubTitle).Append("\",");
                if (this.DefaultAction != null)
                {
                    sb.Append("\"default_action\":").Append(this.DefaultAction.CreateJson()).Append(",");
                }
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
            sb.Append("}");

            return sb.ToString();
        }
    }
}
