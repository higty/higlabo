namespace HigLabo.X;

public class XTweetPublicMetrics
{
    public int Retweet_Count { get; set; }
    public int Reply_Count { get; set; }
    public int Like_Count { get; set; }
    public int Quote_Count { get; set; }
    public int Impression_Count { get; set; }
    public int Bookmark_Count { get; set; }
}
public class XTweetReferencedTweet
{
    public string Type { get; set; } = "";
    public string Id { get; set; } = "";
}
public class XTweet
{
    public string Id { get; set; } = "";
    public string Text { get; set; } = "";
    public string Author_Id { get; set; } = "";
    public string Conversation_Id { get; set; } = "";
    public string Lang { get; set; } = "";
    public DateTimeOffset? Created_At { get; set; }
    public List<string> Edit_History_Tweet_Ids { get; set; } = new();
    public List<XTweetReferencedTweet> Referenced_Tweets { get; set; } = new();
    public XTweetPublicMetrics? Public_Metrics { get; set; }
}
