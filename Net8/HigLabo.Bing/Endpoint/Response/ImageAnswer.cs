namespace HigLabo.Bing
{
    public class ImageAnswer : BingRestApiResponse
    {
        public string Id { get; set; } = "";
        public bool IsFamilyFriendly { get; set; }
        public int NextOffset { get; set; }
        public PivotSegment? PivotSuggestions { get; set; }
        public Query? QqueryExpansions { get; set; }
        public QueryContext? QueryContext { get; set; }
        public string ReadLink { get; set; } = "";
        public Query[]? RelatedSearches { get; set; }
        public Query? SimilarTerms { get; set; }
        public Int64? TotalEstimatedMatches { get; set; } 
        public Image[] Value { get; set; }= Array.Empty<Image>();
        public string WebSearchUrl { get; set; } = "";
    }
}
