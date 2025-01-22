using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/shareddriveitem?view=graph-rest-1.0
/// </summary>
public partial class SharedDriveItem
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public IdentitySet? Owner { get; set; }
    public DriveItem? DriveItem { get; set; }
    public SiteList? List { get; set; }
    public ListItem? ListItem { get; set; }
    public Permission? Permission { get; set; }
    public Site? Site { get; set; }
}
