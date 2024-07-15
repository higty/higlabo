namespace HigLabo.Bing
{
    public enum VideoScenario
    {
        List,
        SingleDominantVideo,
    }
    public class VideosAnswer : BingRestApiResponse
    {
        public string Id { get; set; } = "";
        public bool IsFamilyFriendly { get; set; }
        public int NextOffset { get; set; }
        public PivotSegment[]? PivotSuggestions { get; set; }
        public QueryContext QueryContext { get; set; } = new QueryContext();
        public string ReadLink { get; set; } = "";
        public Query[]? RelatedSearches { get; set; } 
        public VideoScenario? Scenario { get; set; }
        public long? TotalEstimatedMatches { get; set; }
        public Video[] Value { get; set; } = Array.Empty<Video>();
        public string WebSearchUrl { get; set; } = "";
    }
}
