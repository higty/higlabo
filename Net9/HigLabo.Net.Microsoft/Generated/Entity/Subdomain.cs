using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-subdomain?view=graph-rest-1.0
/// </summary>
public partial class Subdomain
{
    public DateTimeOffset? FirstSeenDateTime { get; set; }
    public string? Id { get; set; }
    public Host? Host { get; set; }
}
