using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/implicitgrantsettings?view=graph-rest-1.0
/// </summary>
public partial class ImplicitGrantSettings
{
    public bool? EnableAccessTokenIssuance { get; set; }
    public bool? EnableIdTokenIssuance { get; set; }
}
