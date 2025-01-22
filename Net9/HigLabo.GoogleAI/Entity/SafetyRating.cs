namespace HigLabo.GoogleAI;

public class SafetyRating
{
    public SafetyCategory Category { get; set; }
    public SafetyRatingProbability Probability { get; set; }
    public bool Blocked { get; set; }
}
