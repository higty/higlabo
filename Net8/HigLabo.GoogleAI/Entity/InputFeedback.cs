namespace HigLabo.GoogleAI
{
    public class InputFeedback
    {
        public List<SafetyRating> SafetyRatings { get; init; } = new();
        public BlockReason BlockReason { get; set; }
    }
}
