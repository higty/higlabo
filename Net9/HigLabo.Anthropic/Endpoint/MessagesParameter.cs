using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Anthropic;

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
    public List<AnthropicTool>? Tools { get; set; }
    public object? Tool_Choice { get; set; }
    public object? Thinking { get; set; }

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
            tools = this.Tools,
            tool_choice = this.Tool_Choice,
            thinking = this.Thinking,
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
        this.Tools = tools.ToList();
    }
    public void SetMaxTokens()
    {
        switch (this.Model)
        {
            case ModelNames.ClaudeOpus4_1:
            case ModelNames.ClaudeOpus4:
                this.Max_Tokens = 32000;
                break;
            case ModelNames.ClaudeSonnet4:
            case ModelNames.Claude3_7Sonnet:
                this.Max_Tokens = 64000;
                break;
            case ModelNames.Claude3_5Haiku:
                this.Max_Tokens = 8192;
                break;
            case ModelNames.Claude3Haiku:
                this.Max_Tokens = 4096;
                break;
        }
    }

}
