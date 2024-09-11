using HigLabo.Core;
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

        public FunctionCallResult? GetFunctionCall()
        {
            return this.GetFunctionCallList().FirstOrDefault();
        }
        public List<FunctionCallResult> GetFunctionCallList()
        {
            var l = new List<FunctionCallResult>();
            FunctionCallResult? f = null;

            foreach (var choice in this.Choices)
            {
                if (choice.Message == null) { continue; }
                foreach (var toolCall in choice.Message.Tool_Calls)
                {
                    if (toolCall.Function != null)
                    {
                        if (toolCall.Function.Name.HasValue())
                        {
                            f = l.Find(el => el.Name == toolCall.Function.Name);
                            if (f == null)
                            {
                                f = new FunctionCallResult();
                                f.Name = toolCall.Function.Name;
                                l.Add(f);
                            }
                        }
                        if (f != null)
                        {
                            if (toolCall.Function.Arguments.HasValue())
                            {
                                f.Arguments += toolCall.Function.Arguments;
                            }
                        }
                    }
                }
            }
            return l;
        }
    }
}
