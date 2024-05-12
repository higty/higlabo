using System.Xml.Linq;

namespace HigLabo.OpenAI
{
    public class ToolCall
    {
        public string Id { get; set; } = "";
        public string Type { get; set; } = "";
        public ToolCallFunction Function { get; set; } = new();

        public override string ToString()
        {
            return $"{this.Function.Name} {this.Function.Arguments}";
        }
    }
    public class ToolCallFunction
    {
        public string Name { get; set; } = "";
        public string Arguments { get; set; } = "";

        public override string ToString()
        {
            return $"{Name} {Arguments}";
        }
    }
}
