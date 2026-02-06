namespace HigLabo.X;

public class XSpace
{
    public string Id { get; set; } = "";
    public string State { get; set; } = "";
    public string Title { get; set; } = "";
    public string Host_Ids { get; set; } = "";
    public string Creator_Id { get; set; } = "";
    public string Lang { get; set; } = "";
    public DateTimeOffset? Created_At { get; set; }
    public DateTimeOffset? Scheduled_Start { get; set; }
    public DateTimeOffset? Started_At { get; set; }
    public DateTimeOffset? Ended_At { get; set; }
    public bool Is_Ticketed { get; set; }
}
