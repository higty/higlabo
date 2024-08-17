namespace HigLabo.Bing
{
    public class SearchResponse : BingRestApiResponse
    {
        public Computation? Computation { get; set; }
        public EntityAnswer? Entities { get; set; }
        public ImageAnswer? Images { get; set; }
        public NewsAnswer? News { get; set; }
        public LocalEntityAnswer? Places { get; set; }
        public QueryContext QueryContext { get; set; } = new QueryContext();
        public RankingResponse? RankingResponse { get; set; }
        public RelatedSearchAnswer? RelatedSearches { get; set; }
        public SpellSuggestions? SpellSuggestions { get; set; }
        public TimeZone? TimeZone { get; set; } 
        public TranslationAnswer? Translations { get; set; }
        public VideosAnswer? Videos { get; set; }
        public WebAnswer? WebPages { get; set; }
    }
}
