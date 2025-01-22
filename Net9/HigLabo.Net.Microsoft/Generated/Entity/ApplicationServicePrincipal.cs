using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/applicationserviceprincipal?view=graph-rest-1.0
/// </summary>
public partial class ApplicationServicePrincipal
{
    public Application? Application { get; set; }
    public ServicePrincipal? ServicePrincipal { get; set; }
}
