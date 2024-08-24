using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-taskprocessingresult?view=graph-rest-1.0
    /// </summary>
    public partial class TaskProcessingResult
    {
        public enum TaskProcessingResultIdentityGovernanceLifecycleWorkflowProcessingStatus
        {
            TaskProcessingResult,
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
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? FailureReason { get; set; }
        public string? Id { get; set; }
        public TaskProcessingResultIdentityGovernanceLifecycleWorkflowProcessingStatus ProcessingStatus { get; set; }
        public DateTimeOffset? StartedDateTime { get; set; }
        public User? Subject { get; set; }
        public Task? Task { get; set; }
    }
}
