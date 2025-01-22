using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security?view=graph-rest-1.0
/// </summary>
public partial class Security
{
    public Alert[]? Alerts { get; set; }
    public SecurityAlert[]? Alerts_V2 { get; set; }
    public Incident[]? Incidents { get; set; }
}
