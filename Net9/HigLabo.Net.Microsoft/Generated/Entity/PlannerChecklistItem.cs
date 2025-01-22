using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/plannerchecklistitem?view=graph-rest-1.0
/// </summary>
public partial class PlannerChecklistItem
{
    public bool? IsChecked { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? OrderHint { get; set; }
    public string? Title { get; set; }
}
