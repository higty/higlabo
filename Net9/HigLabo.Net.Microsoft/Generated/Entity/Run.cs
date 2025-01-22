using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-run?view=graph-rest-1.0
/// </summary>
public partial class Run
{
    public enum RunIdentityGovernanceLifecycleWorkflowProcessingStatus
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
    public enum RunIdentityGovernanceWorkflowExecutionType
    {
        Scheduled,
        OnDemand,
        UnknownFutureValue,
        Eq,
        Ne,
    }

    public DateTimeOffset? CompletedDateTime { get; set; }
    public Int32? FailedTasksCount { get; set; }
    public Int32? FailedUsersCount { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastUpdatedDateTime { get; set; }
    public RunIdentityGovernanceLifecycleWorkflowProcessingStatus ProcessingStatus { get; set; }
    public DateTimeOffset? ScheduledDateTime { get; set; }
    public DateTimeOffset? StartedDateTime { get; set; }
    public Int32? SuccessfulUsersCount { get; set; }
    public Int32? TotalUsersCount { get; set; }
    public Int32? TotalTasksCounts { get; set; }
    public Int32? TotalUnprocessedTasksCount { get; set; }
    public RunIdentityGovernanceWorkflowExecutionType WorkflowExecutionType { get; set; }
    public UserProcessingResult[]? UserProcessingResults { get; set; }
    public TaskProcessingResult[]? TaskProcessingResults { get; set; }
    public TaskReport[]? TaskReports { get; set; }
}
