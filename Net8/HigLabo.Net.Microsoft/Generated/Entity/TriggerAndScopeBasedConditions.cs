using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-triggerandscopebasedconditions?view=graph-rest-1.0
    /// </summary>
    public partial class TriggerAndScopeBasedConditions
    {
        public SubjectSet? Scope { get; set; }
        public WorkflowExecutionTrigger? Trigger { get; set; }
    }
}
