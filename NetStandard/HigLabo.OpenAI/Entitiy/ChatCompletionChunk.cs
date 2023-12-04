using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class ChatCompletionChunk
    {
        public class Choice
        {
            public int Index { get; set; }
            public string? Finish_Reason { get; set; }
            public Message Delta { get; set; } = new Message();
            public Message Message { get; set; } = new Message();
        }
        public class Message
        {
            public string? Content { get; set; }
            public FunctionCall? Function_Call { get; set; }
            public List<ToolCall> Tool_Calls { get; set; } = new List<ToolCall>();
            public string Role { get; set; } = "";
        }
        public class FunctionCall
        {
            public string Name { get; set; } = "";
            public string Arguments { get; set; } = "";
        }
        public class ToolCall
        {
            public int Index { get; set; }
            public string Id { get; set; } = "";
            public string Type { get; set; } = "";
            public FunctionCall? Function { get; set; }
        }
        public string Id { get; set; } = "";
        public List<Choice> Choices { get; set; } = new List<Choice>();
        public Int64 Created { get; set; }
        public string Model { get; set; } = "";
        public string Object { get; set; } = "";

        public DateTimeOffset CreateTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created), TimeSpan.Zero);
            }
        }
    }
}
