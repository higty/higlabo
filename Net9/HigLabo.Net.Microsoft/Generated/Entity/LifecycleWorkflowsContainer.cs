using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-lifecycleworkflowscontainer?view=graph-rest-1.0
/// </summary>
public partial class LifecycleWorkflowsContainer
{
    public string? Id { get; set; }
    public CustomTaskExtension[]? CustomTaskExtensions { get; set; }
    public DeletedItemContainer? DeletedItems { get; set; }
    public Insights? Insights { get; set; }
    public LifecycleManagementSettings? Settings { get; set; }
    public TaskDefinition[]? TaskDefinitions { get; set; }
    public Workflow[]? Workflows { get; set; }
    public WorkflowTemplate[]? WorkflowTemplates { get; set; }
}
