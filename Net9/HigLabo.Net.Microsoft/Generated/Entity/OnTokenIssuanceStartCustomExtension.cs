using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/ontokenissuancestartcustomextension?view=graph-rest-1.0
/// </summary>
public partial class OnTokenIssuanceStartCustomExtension
{
    public CustomExtensionAuthenticationConfiguration? AuthenticationConfiguration { get; set; }
    public OnTokenIssuanceStartReturnClaim[]? ClaimsForTokenConfiguration { get; set; }
    public CustomExtensionClientConfiguration? ClientConfiguration { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public CustomExtensionEndpointConfiguration? EndpointConfiguration { get; set; }
    public string? Id { get; set; }
}
