using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-synchronization?view=graph-rest-1.0
/// </summary>
public partial class Synchronization
{
    public string? Id { get; set; }
    public SynchronizationSecretKeyStringValuePair[]? Secrets { get; set; }
    public SynchronizationJob[]? Jobs { get; set; }
    public SynchronizationTemplate[]? Templates { get; set; }
}
