using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-synchronizationerror?view=graph-rest-1.0
/// </summary>
public partial class SynchronizationError
{
    public string? Code { get; set; }
    public string? Message { get; set; }
    public bool? TenantActionable { get; set; }
}
