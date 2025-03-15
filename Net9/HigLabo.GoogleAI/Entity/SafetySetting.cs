namespace HigLabo.GoogleAI;

public class SafetySetting
{
    public SafetyCategory Category { get; set; }
    public Threshold Threshold { get; set; }

    public SafetySetting() { }
    public SafetySetting(SafetyCategory category, Threshold threshold)
    {
        Category = category;
        Threshold = threshold;
    }
}
