using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-taskreport?view=graph-rest-1.0
    /// </summary>
    public partial class TaskReport
    {
        public enum TaskReportIdentityGovernanceLifecycleWorkflowProcessingStatus
        {
            Queued,
            InProgress,
            Completed,
            CompletedWithErrors,
            Canceled,
            Failed,
            UnknownFutureValue,
            Eq,
            Ne,
        }

        public DateTimeOffset? CompletedDateTime { get; set; }
        public Int32? FailedUsersCount { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastUpdatedDateTime { get; set; }
        public TaskReportIdentityGovernanceLifecycleWorkflowProcessingStatus ProcessingStatus { get; set; }
        public string? RunId { get; set; }
        public DateTimeOffset? StartedDateTime { get; set; }
        public Int32? SuccessfulUsersCount { get; set; }
        public Int32? TotalUsersCount { get; set; }
        public Int32? UnprocessedUsersCount { get; set; }
        public Task? Task { get; set; }
        public TaskDefinition? TaskDefinition { get; set; }
        public TaskProcessingResult[]? TaskProcessingResults { get; set; }
    }
}
