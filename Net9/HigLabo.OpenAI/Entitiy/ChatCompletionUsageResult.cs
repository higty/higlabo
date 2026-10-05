namespace HigLabo.OpenAI;

public class ChatCompletionUsageResult
{
    public class PromptTokensDetail
    {
        public int Cached_Tokens { get; set; }
    }
    public PromptTokensDetail Prompt_Tokens_Details { get; set; } = new();
    public int Completion_Tokens { get; set; }
    public int Prompt_Tokens { get; set; }
    public int Total_Tokens { get; set; }
}
