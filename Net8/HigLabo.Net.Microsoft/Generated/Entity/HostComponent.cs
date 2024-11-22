using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-hostcomponent?view=graph-rest-1.0
/// </summary>
public partial class HostComponent
{
    public string? Category { get; set; }
    public DateTimeOffset? FirstSeenDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastSeenDateTime { get; set; }
    public string? Name { get; set; }
    public string? Version { get; set; }
    public Host? Host { get; set; }
}
