using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-taskdefinition?view=graph-rest-1.0
/// </summary>
public partial class TaskDefinition
{
    public enum TaskDefinitionIdentityGovernanceLifecycleTaskCategory
    {
        Joiner,
        Mover,
        Leaver,
        UnknownFutureValue,
        Eq,
        Ne,
        Has,
    }

    public TaskDefinitionIdentityGovernanceLifecycleTaskCategory Category { get; set; }
    public bool? ContinueOnError { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public Parameter[]? Parameters { get; set; }
    public Int32? Version { get; set; }
}
