using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcauditproperty?view=graph-rest-1.0
/// </summary>
public partial class CloudPcAuditProperty
{
    public string? DisplayName { get; set; }
    public string? NewValue { get; set; }
    public string? OldValue { get; set; }
}
