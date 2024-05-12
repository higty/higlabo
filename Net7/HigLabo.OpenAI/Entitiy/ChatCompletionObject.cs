using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class ChatCompletionObjectResponse : RestApiResponse
    {
        public class Choice
        {
            public int Index { get; set; }
            public string? Finish_Reason { get; set; }
            public Message Message { get; set; } = new();
        }
        public class Message
        {
            public string? Content { get; set; }
            public FunctionCall? Function_Call { get; set; }
            public List<ToolCall> Tool_Calls { get; set; } = new();
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
        public List<Choice> Choices { get; set; } = new();
        public Int64 Created { get; set; }
        public DateTimeOffset CreateTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created), TimeSpan.Zero);
            }
        }
        public string Model { get; set; } = "";
        public string System_Fingerprint { get; set; } = "";
        public ChatCompletionUsageResult Usage { get; set; } = new();
    }
}
