using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public partial class ChatCompletionsParameter
{
    public void AddMessage(ChatMessageRole role, string content)
    {
        this.Messages.Add(new ChatMessage(role, content));
    }
    public void AddUserMessage(string content)
    {
        this.Messages.Add(new ChatMessage(ChatMessageRole.User, content));
    }
    public void AddSystemMessage(string content)
    {
        this.Messages.Add(new ChatMessage(ChatMessageRole.System, content));
    }
    public void AddAssistantMessage(string content)
    {
        this.Messages.Add(new ChatMessage(ChatMessageRole.Assistant, content));
    }
    public void AddFunctionMessage(string content)
    {
        this.Messages.Add(new ChatMessage(ChatMessageRole.Function, content));
    }
}
