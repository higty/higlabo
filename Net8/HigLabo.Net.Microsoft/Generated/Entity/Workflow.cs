using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-workflow?view=graph-rest-1.0
    /// </summary>
    public partial class Workflow
    {
        public enum WorkflowIdentityGovernanceLifecycleWorkflowCategory
        {
            Joiner,
            Leaver,
            Mover,
            UnknownFutureValue,
            Eq,
            Ne,
        }

        public WorkflowIdentityGovernanceLifecycleWorkflowCategory Category { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public WorkflowExecutionConditions? ExecutionConditions { get; set; }
        public string? Id { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsSchedulingEnabled { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? NextScheduleRunDateTime { get; set; }
        public Int32? Version { get; set; }
        public User? CreatedBy { get; set; }
        public User[]? ExecutionScope { get; set; }
        public User? LastModifiedBy { get; set; }
        public Run[]? Runs { get; set; }
        public TaskReport[]? TaskReports { get; set; }
        public Task[]? Tasks { get; set; }
        public UserProcessingResult[]? UserProcessingResults { get; set; }
        public WorkflowVersion[]? Versions { get; set; }
    }
}
