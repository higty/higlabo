using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-workflowtemplate?view=graph-rest-1.0
    /// </summary>
    public partial class WorkflowTemplate
    {
        public enum WorkflowTemplateIdentityGovernanceLifecycleWorkflowCategory
        {
            Joiner,
            Mover,
            Leaver,
            UnknownFutureValue,
            Eq,
            Ne,
        }

        public WorkflowTemplateIdentityGovernanceLifecycleWorkflowCategory Category { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public WorkflowExecutionConditions? ExecutionConditions { get; set; }
        public string? Id { get; set; }
        public Task[]? Tasks { get; set; }
    }
}
