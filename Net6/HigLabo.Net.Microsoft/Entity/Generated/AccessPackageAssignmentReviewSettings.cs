using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageassignmentreviewsettings?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAssignmentReviewSettings
    {
        public enum AccessPackageAssignmentReviewSettingsAccessReviewExpirationBehavior
        {
            KeepAccess,
            RemoveAccess,
            AcceptAccessRecommendation,
            UnknownFutureValue,
        }

        public AccessPackageAssignmentReviewSettingsAccessReviewExpirationBehavior ExpirationBehavior { get; set; }
        public SubjectSet[]? FallbackReviewers { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsRecommendationEnabled { get; set; }
        public bool? IsReviewerJustificationRequired { get; set; }
        public bool? IsSelfReview { get; set; }
        public SubjectSet[]? PrimaryReviewers { get; set; }
        public EntitlementManagementSchedule? Schedule { get; set; }
    }
}
