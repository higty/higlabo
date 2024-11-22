using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcmanagementgroupassignmenttarget?view=graph-rest-1.0
/// </summary>
public partial class CloudPcManagementGroupAssignmentTarget
{
    public string? GroupId { get; set; }
    public string? ServicePlanId { get; set; }
}
