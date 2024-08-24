using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-task?view=graph-rest-1.0
    /// </summary>
    public partial class Task
    {
        public enum TaskIdentityGovernanceLifecycleTaskCategory
        {
            Joiner,
            Leaver,
            UnknownFutureValue,
            Eq,
            Ne,
        }

        public KeyValuePair[]? Arguments { get; set; }
        public TaskIdentityGovernanceLifecycleTaskCategory Category { get; set; }
        public bool? ContinueOnError { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? ExecutionSequence { get; set; }
        public string? Id { get; set; }
        public bool? IsEnabled { get; set; }
        public string? TaskDefinitionId { get; set; }
        public TaskProcessingResult[]? TaskProcessingResults { get; set; }
    }
}
