using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-hostportbanner?view=graph-rest-1.0
/// </summary>
public partial class HostPortBanner
{
    public string? Banner { get; set; }
    public DateTimeOffset? FirstSeenDateTime { get; set; }
    public DateTimeOffset? LastSeenDateTime { get; set; }
    public string? ScanProtocol { get; set; }
    public Int32? TimesObserved { get; set; }
}
