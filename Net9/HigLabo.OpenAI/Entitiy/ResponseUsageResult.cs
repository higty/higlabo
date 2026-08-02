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
}
