using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/x509certificatecombinationconfiguration?view=graph-rest-1.0
/// </summary>
public partial class X509CertificateCombinationConfiguration
{
    public String[]? AllowedIssuerSkis { get; set; }
    public String[]? AllowedPolicyOIDs { get; set; }
    public AuthenticationMethodModes[]? AppliesToCombinations { get; set; }
    public string? Id { get; set; }
}
