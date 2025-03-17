namespace HigLabo.GoogleAI;
public class PredictInstance
{
    public string Prompt { get; set; } = "";
    public string Negative_Prompt { get; set; } = "";
    public int? Seed { get; set; }
    public ImageSize? Image_Size { get; set; }
}
