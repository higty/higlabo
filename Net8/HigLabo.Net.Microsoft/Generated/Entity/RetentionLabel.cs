using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-retentionlabel?view=graph-rest-1.0
    /// </summary>
    public partial class RetentionLabel
    {
        public enum RetentionLabelSecurityActionAfterRetentionPeriod
        {
            None,
            Delete,
            StartDispositionReview,
            UnknownFutureValue,
        }
        public enum RetentionLabelSecurityBehaviorDuringRetentionPeriod
        {
            DoNotRetain,
            Retain,
            RetainAsRecord,
            RetainAsRegulatoryRecord,
            UnknownFutureValue,
        }
        public enum RetentionLabelSecurityRetentionTrigger
        {
            DateLabeled,
            DateCreated,
            DateModified,
            DateOfEvent,
            UnknownFutureValue,
        }
        public enum RetentionLabelSecurityDefaultRecordBehavior
        {
            StartLocked,
            StartUnlocked,
            UnknownFutureValue,
        }

        public RetentionLabelSecurityActionAfterRetentionPeriod ActionAfterRetentionPeriod { get; set; }
        public RetentionLabelSecurityBehaviorDuringRetentionPeriod BehaviorDuringRetentionPeriod { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DescriptionForAdmins { get; set; }
        public string? DescriptionForUsers { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsInUse { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public RetentionDuration? RetentionDuration { get; set; }
        public RetentionLabelSecurityRetentionTrigger RetentionTrigger { get; set; }
        public RetentionLabelSecurityDefaultRecordBehavior DefaultRecordBehavior { get; set; }
        public string? LabelToBeApplied { get; set; }
        public DispositionReviewStage[]? DispositionReviewStages { get; set; }
        public RetentionEventType? RetentionEventType { get; set; }
        public FilePlanDescriptor? Descriptors { get; set; }
    }
}
