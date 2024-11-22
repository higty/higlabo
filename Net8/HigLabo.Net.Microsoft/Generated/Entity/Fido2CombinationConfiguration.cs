using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/fido2combinationconfiguration?view=graph-rest-1.0
/// </summary>
public partial class Fido2CombinationConfiguration
{
    public String[]? AllowedAAGUIDs { get; set; }
    public AuthenticationMethodModes[]? AppliesToCombinations { get; set; }
    public string? Id { get; set; }
}
