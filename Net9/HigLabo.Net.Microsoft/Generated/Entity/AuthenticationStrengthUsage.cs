using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/authenticationstrengthusage?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationStrengthUsage
{
    public ConditionalAccessPolicy[]? Mfa { get; set; }
    public ConditionalAccessPolicy[]? None { get; set; }
}
