using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewinstancedecisionitemazureroleresource?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewInstanceDecisionItemAzureRoleResource
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? Type { get; set; }
        public AccessReviewInstanceDecisionItemResource? Scope { get; set; }
    }
}
