using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/conditionalaccessroot?view=graph-rest-1.0
/// </summary>
public partial class ConditionalAccessRoot
{
    public AuthenticationContextClassReference[]? AuthenticationContextClassReferences { get; set; }
    public NamedLocation[]? NamedLocations { get; set; }
    public ConditionalAccessPolicy[]? Policies { get; set; }
    public ConditionalAccessTemplate[]? Templates { get; set; }
}
