using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-whoisnameserver?view=graph-rest-1.0
/// </summary>
public partial class WhoisNameserver
{
    public DateTimeOffset? FirstSeenDateTime { get; set; }
    public DateTimeOffset? LastSeenDateTime { get; set; }
    public Host? Host { get; set; }
}
