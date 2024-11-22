using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-hostsslcertificate?view=graph-rest-1.0
/// </summary>
public partial class HostSslCertificate
{
    public DateTimeOffset? FirstSeenDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastSeenDateTime { get; set; }
    public HostSslCertificatePort[]? Ports { get; set; }
    public Host? Host { get; set; }
    public SslCertificate? SslCertificate { get; set; }
}
