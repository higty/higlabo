using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/builtinidentityprovider?view=graph-rest-1.0
/// </summary>
public partial class BuiltInIdentityProvider
{
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? IdentityProviderType { get; set; }
}
