using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/provisioningsystem?view=graph-rest-1.0
/// </summary>
public partial class ProvisioningSystem
{
    public string? DisplayName { get; set; }
    public DetailsInfo? Details { get; set; }
    public string? Id { get; set; }
}
