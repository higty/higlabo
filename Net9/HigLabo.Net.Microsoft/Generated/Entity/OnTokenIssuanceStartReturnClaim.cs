using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/ontokenissuancestartreturnclaim?view=graph-rest-1.0
/// </summary>
public partial class OnTokenIssuanceStartReturnClaim
{
    public string? ClaimIdInApiResponse { get; set; }
}
