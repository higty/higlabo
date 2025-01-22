using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-userprocessingresult?view=graph-rest-1.0
/// </summary>
public partial class UserProcessingResult
{
    public enum UserProcessingResultIdentityGovernanceLifecycleWorkflowProcessingStatus
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
    public enum UserProcessingResultIdentityGovernanceWorkflowExecutionType
    {
        Scheduled,
        OnDemand,
        UnknownFutureValue,
        Lt,
        Le,
        Gt,
        Ge,
        Eq,
        Ne,
    }

    public DateTimeOffset? CompletedDateTime { get; set; }
    public Int32? FailedTasksCount { get; set; }
    public string? Id { get; set; }
    public UserProcessingResultIdentityGovernanceLifecycleWorkflowProcessingStatus ProcessingStatus { get; set; }
    public DateTimeOffset? ScheduledDateTime { get; set; }
    public DateTimeOffset? StartedDateTime { get; set; }
    public Int32? TotalTasksCount { get; set; }
    public Int32? TotalUnprocessedTasksCount { get; set; }
    public UserProcessingResultIdentityGovernanceWorkflowExecutionType WorkflowExecutionType { get; set; }
    public Int32? WorkflowVersion { get; set; }
    public User? Subject { get; set; }
    public TaskProcessingResult[]? TaskProcessingResults { get; set; }
}
