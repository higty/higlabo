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
    public decimal? CalculateCost(string modelName)
    {
        switch (modelName.Trim().ToLowerInvariant())
        {
            case ModelNames.ClaudeOpus4_8:
            case ModelNames.ClaudeOpus4_7:
            case ModelNames.ClaudeOpus4_6:
            case ModelNames.ClaudeOpus4_5:
                return this.CalculateCost(5.00m, 6.25m, 10.00m, 0.50m, 25.00m);
            case ModelNames.ClaudeOpus4_1:
            case ModelNames.ClaudeOpus4:
                return this.CalculateCost(15.00m, 18.75m, 30.00m, 1.50m, 75.00m);
            case ModelNames.ClaudeSonnet4_6:
            case ModelNames.ClaudeSonnet4_5:
            case ModelNames.ClaudeSonnet4:
            case ModelNames.Claude3_7Sonnet:
                return this.CalculateCost(3.00m, 3.75m, 6.00m, 0.30m, 15.00m);
            case ModelNames.ClaudeHaiku4_5:
                return this.CalculateCost(1.00m, 1.25m, 2.00m, 0.10m, 5.00m);
            case ModelNames.Claude3_5Haiku:
                return this.CalculateCost(0.80m, 1.00m, 1.60m, 0.08m, 4.00m);
            case ModelNames.Claude3Haiku:
                return this.CalculateCost(0.25m, 0.30m, 0.50m, 0.03m, 1.25m);
            default: return null;
        }
    }
    public decimal CalculateCost(decimal inputPrice, decimal cacheWrite5mPrice, decimal cacheWrite1hPrice, decimal cacheReadPrice, decimal outputPrice)
    {
        return (
            (this.Input_Tokens * inputPrice) +
            (this.GetCacheCreation5mInputTokens() * cacheWrite5mPrice) +
            (this.Cache_Creation.Ephemeral_1h_Input_Tokens * cacheWrite1hPrice) +
            (this.Cache_Read_Input_Tokens * cacheReadPrice) +
            (this.Output_Tokens * outputPrice)
        ) / 1_000_000m;
    }
}
