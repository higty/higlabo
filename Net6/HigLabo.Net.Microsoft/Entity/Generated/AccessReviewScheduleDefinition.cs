using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/accessreviewscheduledefinition?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewScheduleDefinition
    {
        public AccessReviewNotificationRecipientItem[] AdditionalNotificationRecipients { get; set; }
        public UserIdentity? CreatedBy { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string DescriptionForAdmins { get; set; }
        public string DescriptionForReviewers { get; set; }
        public string DisplayName { get; set; }
        public AccessReviewReviewerScope[] FallbackReviewers { get; set; }
        public string Id { get; set; }
        public AccessReviewScope? InstanceEnumerationScope { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public AccessReviewReviewerScope[] Reviewers { get; set; }
        public AccessReviewScope? Scope { get; set; }
        public AccessReviewScheduleSettings? Settings { get; set; }
        public string Status { get; set; }
    }
}
