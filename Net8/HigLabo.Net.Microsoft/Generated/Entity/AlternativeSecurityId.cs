using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/alternativesecurityid?view=graph-rest-1.0
/// </summary>
public partial class AlternativeSecurityId
{
    public string? IdentityProvider { get; set; }
    public string? Key { get; set; }
    public Int32? Type { get; set; }
}
