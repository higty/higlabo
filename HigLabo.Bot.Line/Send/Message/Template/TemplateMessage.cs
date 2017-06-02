using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Bot.Line.Send
{
    public interface ITemplate : ISendMessage
    {
    }
    public class TemplateMessage<T> : ISendMessage
        where T : ITemplate, new()
    {
        public String AltText { get; set; }
        public T Template { get; set; } = new T();

        public string CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"type\":\"template\",");
                sb.Append("\"altText\":\"").AppendJsonEncoded(this.AltText).Append("\",");
                sb.Append("\"template\":").Append(this.Template.CreateJson());
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
