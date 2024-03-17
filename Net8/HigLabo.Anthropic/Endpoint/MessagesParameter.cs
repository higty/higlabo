using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Anthropic
{
    public partial class MessagesParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Model { get; set; } = "";
        public List<IChatMessage> Messages { get; set; } = new();
        public string System { get; set; } = "";
        public int Max_Tokens { get; set; } = 1024;
        public object? MetaData { get; set; }
        public List<string>? Stop_Sequences { get; set; }
        public bool? Stream { get; set; }
        public double? Temperature { get; set; }
        public double? Top_P { get; set; }
        public int? Top_K { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/messages";
        }
        public override object GetRequestBody()
        {
            return new
            {
                model = this.Model,
                messages = this.Messages,
                system = this.System,
                max_tokens = this.Max_Tokens,
                metadata= this.MetaData,
                stop_sequences = this.Stop_Sequences,
                stream = this.Stream,
                temperature = this.Temperature,
                top_p = this.Top_P,
                top_k = this.Top_K,
            };
        }

        public void AddMessage(ChatMessageRole role, string content)
        {
            this.Messages.Add(new ChatMessage(role, content));
        }
        public void AddUserMessage(string content)
        {
            this.Messages.Add(new ChatMessage(ChatMessageRole.User, content));
        }
        public void AddAssistantMessage(string content)
        {
            this.Messages.Add(new ChatMessage(ChatMessageRole.Assistant, content));
        }
        public void SetTools(AnthropicTools tools)
        {
            this.System = $@"In this environment you have access to a set of tools you can use to answer the user's question.

You may call them like this:
<function_calls>
<invoke>
<tool_name>$TOOL_NAME</tool_name>
<parameters>
<$PARAMETER_NAME>$PARAMETER_VALUE</$PARAMETER_NAME>
...
</parameters>
</invoke>
</function_calls>

Here are the tools available:
{tools}
";
        }

    }
}
