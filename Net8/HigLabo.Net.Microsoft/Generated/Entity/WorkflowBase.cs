using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-workflowbase?view=graph-rest-1.0
/// </summary>
public partial class WorkflowBase
{
    public enum WorkflowBaseIdentityGovernanceLifecycleWorkflowCategory
    {
        Joiner,
        Leaver,
        Mover,
        UnknownFutureValue,
    }

    public WorkflowBaseIdentityGovernanceLifecycleWorkflowCategory Category { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public WorkflowExecutionConditions? ExecutionConditions { get; set; }
    public bool? IsEnabled { get; set; }
    public bool? IsSchedulingEnabled { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public User? CreatedBy { get; set; }
    public User? LastModifiedBy { get; set; }
    public Task[]? Tasks { get; set; }
}
