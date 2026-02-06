namespace HigLabo.X;

public class XMatchingRule
{
    public string Id { get; set; } = "";
    public string Tag { get; set; } = "";
}
public class XFilteredStreamResponse : XApiResult<XTweet>
{
    public List<XMatchingRule> Matching_Rules { get; set; } = new();
}
public class XSampleStreamResponse : XApiResult<XTweet>
{
}
