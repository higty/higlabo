using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-cloudapplicationevidence?view=graph-rest-1.0
/// </summary>
public partial class CloudApplicationEvidence
{
    public Int64? AppId { get; set; }
    public string? DisplayName { get; set; }
    public Int64? InstanceId { get; set; }
    public string? InstanceName { get; set; }
    public Int64? SaasAppId { get; set; }
}
