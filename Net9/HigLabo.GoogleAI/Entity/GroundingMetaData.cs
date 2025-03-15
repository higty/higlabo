namespace HigLabo.GoogleAI;

public class GroundingMetaData
{
    public List<string>? WebSearchQueries { get; set; }
    public SearchEntryPoint? SearchEntryPoint { get; set; }
    public List<GroundingChunk> GroundingChunks { get; set; } = new();
    public List<GroundingSupport> GroundingSupports { get; set; } = new();
    public object? RetrievalMetadata { get; set; }
}
public class SearchEntryPoint
{
    public string RenderedContent { get; set; } = "";
}
public class GroundingChunk
{
    public GroundingChunkWeb Web { get; set; } = new();
}
public class GroundingChunkWeb
{
    public string Uri { get; set; } = "";
    public string Title { get; set; } = "";
}
public class GroundingSupport
{
    public GroundingSupportSegment Segment { get; set; } = new();
    public List<int> GroundingChunkIndices { get; set; } = new();
    public List<float> ConfidenceScores { get; set; } = new();
}
public class GroundingSupportSegment
{
    public int? StartIndex { get; set; }
    public int? EndIndex { get; set; }
    public string Text { get; set; } = "";
}


