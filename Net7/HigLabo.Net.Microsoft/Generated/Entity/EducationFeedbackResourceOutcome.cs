using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/educationfeedbackresourceoutcome?view=graph-rest-1.0
    /// </summary>
    public partial class EducationFeedbackResourceOutcome
    {
        public enum EducationFeedbackResourceOutcomeEducationFeedbackResourceOutcomeStatus
        {
            NotPublished,
            PendingPublish,
            Published,
            FailedPublish,
            UnknownFutureValue,
        }

        public EducationResource? FeedbackResource { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public EducationFeedbackResourceOutcomeEducationFeedbackResourceOutcomeStatus ResourceStatus { get; set; }
    }
}
