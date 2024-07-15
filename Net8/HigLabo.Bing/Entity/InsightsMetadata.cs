namespace HigLabo.Bing
{
    public class InsightsMetadata
    {
        public Offer AggregateOffer { get; set; } = new Offer();
        public UInt32? AvailableSizesCount { get; set; }
        public UInt32? PagesIncludingCount { get; set; }
        public UInt32? RecipeSourcesCount { get; set; }
        public UInt32? ShoppingSourcesCount { get; set; }
    }
}
