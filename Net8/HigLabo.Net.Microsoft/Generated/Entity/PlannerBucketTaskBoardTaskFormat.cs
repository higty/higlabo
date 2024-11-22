using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/plannerbuckettaskboardtaskformat?view=graph-rest-1.0
/// </summary>
public partial class PlannerBucketTaskBoardTaskFormat
{
    public string? Id { get; set; }
    public string? OrderHint { get; set; }
}
