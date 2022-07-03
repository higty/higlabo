using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/accessreviewinstancedecisionitem?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewInstanceDecisionItem
    {
        public string AccessReviewId { get; set; }
        public UserIdentity? AppliedBy { get; set; }
        public DateTimeOffset AppliedDateTime { get; set; }
        public string ApplyResult { get; set; }
        public string Decision { get; set; }
        public string Id { get; set; }
        public string Justification { get; set; }
        public Identity? Principal { get; set; }
        public string PrincipalLink { get; set; }
        public string Recommendation { get; set; }
        public AccessReviewInstanceDecisionItemResource? Resource { get; set; }
        public string ResourceLink { get; set; }
        public UserIdentity? ReviewedBy { get; set; }
        public DateTimeOffset ReviewedDateTime { get; set; }
    }
}
