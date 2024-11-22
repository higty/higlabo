using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-externalgroup?view=graph-rest-1.0
/// </summary>
public partial class ExternalConnectorsExternalGroup
{
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public ExternalConnectorsIdentity[]? Members { get; set; }
}
