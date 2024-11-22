using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/groupmembers?view=graph-rest-1.0
/// </summary>
public partial class GroupMembers
{
    public string? Description { get; set; }
    public string? GroupId { get; set; }
}
