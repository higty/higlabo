using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-synchronizationtemplate?view=graph-rest-1.0
/// </summary>
public partial class SynchronizationTemplate
{
    public string? Id { get; set; }
    public string? ApplicationId { get; set; }
    public bool? Default { get; set; }
    public string? Description { get; set; }
    public string? Discoverable { get; set; }
    public string? FactoryTag { get; set; }
    public SynchronizationMetadataEntry[]? Metadata { get; set; }
    public SynchronizationSchema? Schema { get; set; }
}
