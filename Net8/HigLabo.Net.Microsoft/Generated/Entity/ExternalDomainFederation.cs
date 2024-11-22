using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/externaldomainfederation?view=graph-rest-1.0
/// </summary>
public partial class ExternalDomainFederation
{
    public string? DisplayName { get; set; }
    public string? DomainName { get; set; }
    public string? IssuerUri { get; set; }
}
