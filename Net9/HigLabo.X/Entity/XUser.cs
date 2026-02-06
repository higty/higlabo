namespace HigLabo.X;

public class XUserPublicMetrics
{
    public int Followers_Count { get; set; }
    public int Following_Count { get; set; }
    public int Tweet_Count { get; set; }
    public int Listed_Count { get; set; }
}
public class XUser
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Username { get; set; } = "";
    public DateTimeOffset? Created_At { get; set; }
    public string Description { get; set; } = "";
    public string Location { get; set; } = "";
    public string Url { get; set; } = "";
    public string Profile_Image_Url { get; set; } = "";
    public string Pinned_Tweet_Id { get; set; } = "";
    public bool Protected { get; set; }
    public bool Verified { get; set; }
    public XUserPublicMetrics? Public_Metrics { get; set; }
}
