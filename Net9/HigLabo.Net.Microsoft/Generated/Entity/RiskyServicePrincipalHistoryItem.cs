using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/riskyserviceprincipalhistoryitem?view=graph-rest-1.0
/// </summary>
public partial class RiskyServicePrincipalHistoryItem
{
    public RiskServicePrincipalActivity? Activity { get; set; }
    public bool? InitiatedBy { get; set; }
    public string? ServicePrincipalId { get; set; }
}
