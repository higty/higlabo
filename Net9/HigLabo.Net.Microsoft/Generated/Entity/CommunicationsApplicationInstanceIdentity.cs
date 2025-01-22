using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/communicationsapplicationinstanceidentity?view=graph-rest-1.0
/// </summary>
public partial class CommunicationsApplicationInstanceIdentity
{
    public string? DisplayName { get; set; }
    public bool? Hidden { get; set; }
    public string? Id { get; set; }
    public string? TenantId { get; set; }
}
