namespace HigLabo.OpenAI;

public class ResponseUsageResult
{
    public class InputTokensDetail
    {
        public int Cached_Tokens { get; set; }
    }
    public class OutputTokensDetail
    {
        public int Reasoning_Tokens { get; set;}
    }
    public int Input_Tokens { get; set; }
    public InputTokensDetail Input_Tokens_Details { get; set; } = new();
    public int Output_Tokens { get; set; }
    public OutputTokensDetail Output_Tokens_Details { get; set; } = new();
    public int Total_Tokens { get; set; }

    public decimal? CalculateCost(string modelName)
    {
        switch (modelName.Trim().ToLowerInvariant())
        {
            case "gpt-5.6":
            case "gpt-5.6-sol":
                return this.CalculateCost(5.00m, 0.50m, 30.00m);
            case "gpt-5.6-terra": return this.CalculateCost(2.50m, 0.25m, 15.00m);
            case "gpt-5.6-luna": return this.CalculateCost(1.00m, 0.10m, 6.00m);
            case "gpt-5.5": return this.CalculateCost(5.00m, 0.50m, 30.00m);
            case "gpt-5.5-pro": return this.CalculateCost(30.00m, 30.00m, 180.00m);
            case "gpt-5.4": return this.CalculateCost(2.50m, 0.25m, 15.00m);
            case "gpt-5.4-mini": return this.CalculateCost(0.75m, 0.075m, 4.50m);
            case "gpt-5.4-nano": return this.CalculateCost(0.20m, 0.02m, 1.25m);
            case "gpt-5.4-pro": return this.CalculateCost(30.00m, 30.00m, 180.00m);
            case "gpt-5.2":
            case "gpt-5.2-chat-latest":
            case "gpt-5.2-codex":
                return this.CalculateCost(1.75m, 0.175m, 14.00m);
            case "gpt-5.1":
            case "gpt-5.1-chat-latest":
            case "gpt-5.1-codex":
            case "gpt-5.1-codex-max":
                return this.CalculateCost(1.25m, 0.125m, 10.00m);
            case "gpt-5":
            case "gpt-5-chat-latest":
            case "gpt-5-codex":
            case "gpt-5-search-api":
                return this.CalculateCost(1.25m, 0.125m, 10.00m);
            case "gpt-5-mini":
            case "gpt-5.1-codex-mini":
                return this.CalculateCost(0.25m, 0.025m, 2.00m);
            case "gpt-5-nano": return this.CalculateCost(0.05m, 0.005m, 0.40m);
            case "gpt-5.2-pro": return this.CalculateCost(21.00m, 21.00m, 168.00m);
            case "gpt-5-pro": return this.CalculateCost(15.00m, 15.00m, 120.00m);
            case "gpt-4.1": return this.CalculateCost(2.00m, 0.50m, 8.00m);
            case "gpt-4.1-mini": return this.CalculateCost(0.40m, 0.10m, 1.60m);
            case "gpt-4.1-nano": return this.CalculateCost(0.10m, 0.025m, 0.40m);
            case "gpt-4o": return this.CalculateCost(2.50m, 1.25m, 10.00m);
            case "gpt-4o-2024-05-13": return this.CalculateCost(5.00m, 5.00m, 15.00m);
            case "gpt-4o-mini": return this.CalculateCost(0.15m, 0.075m, 0.60m);
            case "chat-latest": return this.CalculateCost(5.00m, 0.50m, 30.00m);
            case "chatgpt-4o-latest": return this.CalculateCost(5.00m, 5.00m, 15.00m);
            case "gpt-realtime-2": return this.CalculateCost(4.00m, 0.40m, 24.00m);
            case "gpt-realtime": return this.CalculateCost(4.00m, 0.40m, 16.00m);
            case "gpt-realtime-mini": return this.CalculateCost(0.60m, 0.06m, 2.40m);
            case "gpt-4o-realtime-preview": return this.CalculateCost(5.00m, 2.50m, 20.00m);
            case "gpt-4o-mini-realtime-preview": return this.CalculateCost(0.60m, 0.30m, 2.40m);
            case "gpt-audio": return this.CalculateCost(2.50m, 2.50m, 10.00m);
            case "gpt-audio-mini": return this.CalculateCost(0.60m, 0.60m, 2.40m);
            case "gpt-4o-audio-preview": return this.CalculateCost(2.50m, 2.50m, 10.00m);
            case "gpt-4o-mini-audio-preview": return this.CalculateCost(0.15m, 0.15m, 0.60m);
            case "o1": return this.CalculateCost(15.00m, 7.50m, 60.00m);
            case "o1-pro": return this.CalculateCost(150.00m, 150.00m, 600.00m);
            case "o3-pro": return this.CalculateCost(20.00m, 20.00m, 80.00m);
            case "o3": return this.CalculateCost(2.00m, 0.50m, 8.00m);
            case "o3-deep-research": return this.CalculateCost(10.00m, 2.50m, 40.00m);
            case "o4-mini": return this.CalculateCost(1.10m, 0.275m, 4.40m);
            case "o4-mini-deep-research": return this.CalculateCost(2.00m, 0.50m, 8.00m);
            case "o3-mini":
            case "o1-mini":
                return this.CalculateCost(1.10m, 0.55m, 4.40m);
            case "gpt-5.3-codex": return this.CalculateCost(1.75m, 0.175m, 14.00m);
            case "codex-mini-latest": return this.CalculateCost(1.50m, 0.375m, 6.00m);
            case "gpt-4o-mini-search-preview": return this.CalculateCost(0.15m, 0.15m, 0.60m);
            case "gpt-4o-search-preview": return this.CalculateCost(2.50m, 2.50m, 10.00m);
            case "computer-use-preview": return this.CalculateCost(3.00m, 3.00m, 12.00m);
            case "gpt-image-1.5":
            case "chatgpt-image-latest":
                return this.CalculateCost(5.00m, 1.25m, 10.00m);
            case "gpt-image-2": return this.CalculateCost(5.00m, 1.25m, 30.00m);
            case "gpt-image-1": return this.CalculateCost(5.00m, 1.25m, 0m);
            case "gpt-image-1-mini": return this.CalculateCost(2.00m, 0.20m, 0m);
            case "gpt-4-turbo-2024-04-09":
            case "gpt-4-0125-preview":
            case "gpt-4-1106-preview":
            case "gpt-4-1106-vision-preview":
                return this.CalculateCost(10.00m, 10.00m, 30.00m);
            case "gpt-4-0613":
            case "gpt-4-0314":
                return this.CalculateCost(30.00m, 30.00m, 60.00m);
            case "gpt-4-32k": return this.CalculateCost(60.00m, 60.00m, 120.00m);
            case "gpt-3.5-turbo":
            case "gpt-3.5-turbo-0125":
                return this.CalculateCost(0.50m, 0.50m, 1.50m);
            case "gpt-3.5-turbo-1106": return this.CalculateCost(1.00m, 1.00m, 2.00m);
            case "gpt-3.5-turbo-0613":
            case "gpt-3.5-0301":
            case "gpt-3.5-turbo-instruct":
                return this.CalculateCost(1.50m, 1.50m, 2.00m);
            case "gpt-3.5-turbo-16k-0613": return this.CalculateCost(3.00m, 3.00m, 4.00m);
            case "davinci-002": return this.CalculateCost(2.00m, 2.00m, 2.00m);
            case "babbage-002": return this.CalculateCost(0.40m, 0.40m, 0.40m);
            default: return null;
        }
    }
    public decimal CalculateCost(decimal inputPrice, decimal cachedPrice, decimal outputPrice)
    {
        return (
            ((this.Input_Tokens - this.Input_Tokens_Details.Cached_Tokens) * inputPrice) +
            (this.Input_Tokens_Details.Cached_Tokens * cachedPrice) +
            (this.Output_Tokens * outputPrice)
        ) / 1_000_000m;
    }
}
