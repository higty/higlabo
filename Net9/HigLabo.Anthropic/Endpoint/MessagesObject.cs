using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Anthropic;

public class MessagesObject
{
    public string Id { get; set; } = "";
    public string Type { get; set; } = "";
    public string Role { get; set; } = "";
    public List<MessageText> Content { get; set; } = new();
    public string Model { get; set; } = "";
    public string Stop_Reason { get; set; } = "";
    public string? Stop_Sequence { get; set; } 
    public MessageUsage Usage { get; set; } = new();

    public string GetStopReason()
    {
        return this.Stop_Reason;
    }
    public FunctionCallResult? GetFunctionCall()
    {
        return this.GetFunctionCallList().FirstOrDefault();
    }
    public List<FunctionCallResult> GetFunctionCallList()
    {
        return MessageText.GetFunctionCallList(this.Content);
    }
}
public class MessagesObjectResponse: RestApiResponse
{
    public string Id { get; set; } = "";
    public string Type { get; set; } = "";
    public string Role { get; set; } = "";
    public List<MessageText> Content { get; set; } = new();
    public string Model { get; set; } = "";
    public string Stop_Reason { get; set; } = "";
    public string? Stop_Sequence { get; set; }
    public MessageUsage Usage { get; set; } = new();

    public FunctionCallResult? GetFunctionCall()
    {
        return this.GetFunctionCallList().FirstOrDefault();
    }
    public string GetStopReason()
    {
        return this.Stop_Reason;
    }
    public List<FunctionCallResult> GetFunctionCallList()
    {
        return MessageText.GetFunctionCallList(this.Content);
    }
}
public class MessageText
{
    public string Type { get; set; } = "";
    public string Text { get; set; } = "";
    public string? Id { get; set; }
    public string? Name { get; set; }
    public object? Input { get; set; }

    public static List<FunctionCallResult> GetFunctionCallList(IEnumerable<MessageText> content)
    {
        var l = new List<FunctionCallResult>();
        foreach (var item in content)
        {
            if (string.Equals(item.Type, "tool_use", StringComparison.OrdinalIgnoreCase) == false) { continue; }
            l.Add(new FunctionCallResult
            {
                Name = item.Name ?? "",
                Arguments = item.Input == null ? "" : global::Newtonsoft.Json.JsonConvert.SerializeObject(item.Input),
            });
        }
        return l;
    }
}
public class MessageUsage
{
    public class CacheCreationUsage
    {
        public int Ephemeral_5m_Input_Tokens { get; set; }
        public int Ephemeral_1h_Input_Tokens { get; set; }
    }
    public int Input_Tokens { get; set; }
    public int Cache_Creation_Input_Tokens { get; set; }
    public int Cache_Read_Input_Tokens { get; set; }
    public CacheCreationUsage Cache_Creation { get; set; } = new();
    public int Output_Tokens { get; set; }

    public int GetCacheCreation5mInputTokens()
    {
        if (this.Cache_Creation.Ephemeral_5m_Input_Tokens > 0) { return this.Cache_Creation.Ephemeral_5m_Input_Tokens; }
        return Math.Max(0, this.Cache_Creation_Input_Tokens - this.Cache_Creation.Ephemeral_1h_Input_Tokens);
    }
    public int GetTotalInputTokens()
    {
        return this.Input_Tokens + this.Cache_Creation_Input_Tokens + this.Cache_Read_Input_Tokens;
    }
}
