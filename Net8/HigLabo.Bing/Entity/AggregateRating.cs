namespace HigLabo.Bing
{
    public class AggregateRating
    {
        public float? BestRating { get; set; }
        public float? RatingValue { get; set; }
        public UInt32? ReviewCount { get; set; }
        public string Text { get; set; } = "";
    }
}
