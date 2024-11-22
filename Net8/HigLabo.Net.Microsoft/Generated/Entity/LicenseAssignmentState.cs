using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/licenseassignmentstate?view=graph-rest-1.0
/// </summary>
public partial class LicenseAssignmentState
{
    public string? AssignedByGroup { get; set; }
    public String[]? DisabledPlans { get; set; }
    public string? Error { get; set; }
    public DateTimeOffset? LastUpdatedDateTime { get; set; }
    public string? SkuId { get; set; }
    public string? State { get; set; }
}
