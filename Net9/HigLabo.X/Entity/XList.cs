namespace HigLabo.X;

public class XList
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public bool Private { get; set; }
    public string Owner_Id { get; set; } = "";
    public int Follower_Count { get; set; }
    public int Member_Count { get; set; }
}
