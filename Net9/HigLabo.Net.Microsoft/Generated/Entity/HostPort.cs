using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-hostport?view=graph-rest-1.0
/// </summary>
public partial class HostPort
{
    public enum HostPortSecurityHostPortProtocol
    {
        Tcp,
        Udp,
        UnknownFutureValue,
    }
    public enum HostPortSecurityHostPortStatus
    {
        Open,
        Filtered,
        Closed,
        UnknownFutureValue,
    }

    public HostPortBanner[]? Banners { get; set; }
    public DateTimeOffset? FirstSeenDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastScanDateTime { get; set; }
    public DateTimeOffset? LastSeenDateTime { get; set; }
    public Int32? Port { get; set; }
    public HostPortSecurityHostPortProtocol Protocol { get; set; }
    public HostPortComponent[]? Services { get; set; }
    public HostPortSecurityHostPortStatus Status { get; set; }
    public Int32? TimesObserved { get; set; }
    public Host? Host { get; set; }
    public SslCertificate? MostRecentSslCertificate { get; set; }
}
