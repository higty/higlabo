using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/logicapptriggerendpointconfiguration?view=graph-rest-1.0
/// </summary>
public partial class LogicAppTriggerEndpointConfiguration
{
    public string? LogicAppWorkflowName { get; set; }
    public string? ResourceGroupName { get; set; }
    public string? SubscriptionId { get; set; }
    public string? Url { get; set; }
}
