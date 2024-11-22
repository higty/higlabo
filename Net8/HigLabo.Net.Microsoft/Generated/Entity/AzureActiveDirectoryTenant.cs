using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/azureactivedirectorytenant?view=graph-rest-1.0
/// </summary>
public partial class AzureActiveDirectoryTenant
{
    public string? DisplayName { get; set; }
    public string? TenantId { get; set; }
}
