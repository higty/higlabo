using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/authenticationcombinationconfiguration?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationCombinationConfiguration
{
    public AuthenticationMethodModes[]? AppliesToCombinations { get; set; }
    public string? Id { get; set; }
}
