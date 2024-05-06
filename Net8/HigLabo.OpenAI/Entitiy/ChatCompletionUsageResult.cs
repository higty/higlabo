namespace HigLabo.OpenAI
{
    public class ChatCompletionUsageResult
    {
        public int Completion_Tokens { get; set; }
        public int Prompt_Tokens { get; set; }
        public int Total_Tokens { get; set; }
    }
}
