using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Bot.Line.Send
{
    public class CarouselTemplate : TemplateMessage
    {
        public String ThumbnailImageUrl { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }
        public List<CarouselColumn> Columns { get; private set; } = new List<CarouselColumn>();

        public override string CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"type\":\"template\",");
                sb.Append("\"altText\":\"").AppendJsonEncoded(this.AltText).Append("\",");
                sb.Append("\"template\": {");
                {
                    sb.Append("\"type\":\"carousel\",");
                    sb.Append("\"columns\":[");
                    for (int i = 0; i < this.Columns.Count; i++)
                    {
                        sb.Append(this.Columns[i].CreateJson());
                        if (i < this.Columns.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.Append("]");
                }
                sb.Append("}");
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
    public class CarouselColumn : ISendMessage
    {
        public String ThumbnailImageUrl { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }
        public List<TemplateAction> Actions { get; private set; } = new List<TemplateAction>();

        public string CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"text\":\"").AppendJsonEncoded(this.Text).Append("\",");
                if (this.ThumbnailImageUrl.IsNullOrEmpty() == false)
                {
                    sb.Append("\"thumbnailImageUrl\":\"").AppendJsonEncoded(this.ThumbnailImageUrl).Append("\",");
                }
                if (this.Title.IsNullOrEmpty() == false)
                {
                    sb.Append("\"title\":\"").AppendJsonEncoded(this.Title).Append("\",");
                }
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
