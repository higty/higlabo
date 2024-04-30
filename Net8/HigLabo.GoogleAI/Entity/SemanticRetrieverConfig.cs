namespace HigLabo.GoogleAI
{
    public class SemanticRetrieverConfig
    {
        public string Source { get; set; } = "";
        public Content Query { get; init; } = new Content();
        public List<MetadataFilter>? MetadataFilters { get; set; } 
        public int? MaxChunksCount { get; set; }
        public Double? MinimumRelevanceScore { get; set; }
    }
}
