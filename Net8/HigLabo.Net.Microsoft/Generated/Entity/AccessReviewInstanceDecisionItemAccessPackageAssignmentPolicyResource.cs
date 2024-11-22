using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewinstancedecisionitemaccesspackageassignmentpolicyresource?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewInstanceDecisionItemAccessPackageAssignmentPolicyResource
{
    public string? AccessPackageDisplayName { get; set; }
    public string? AccessPackageId { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? Type { get; set; }
}
