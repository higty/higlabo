namespace HigLabo.OpenAI;
public class ImageGenerationUsage
{
    public int Input_Tokens { get; set; }
    public TokensDetails Input_Tokens_Details { get; set; } = new TokensDetails();
    public int Output_Tokens { get; set; }
    public int Total_Tokens { get; set; }

    public class TokensDetails
    {
        public int Image_Tokens { get; set; }
        public int Text_Tokens { get; set; }
    }

}
