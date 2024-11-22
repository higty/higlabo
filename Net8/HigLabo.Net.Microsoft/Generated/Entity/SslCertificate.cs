using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-sslcertificate?view=graph-rest-1.0
/// </summary>
public partial class SslCertificate
{
    public DateTimeOffset? ExpirationDateTime { get; set; }
    public string? Fingerprint { get; set; }
    public DateTimeOffset? FirstSeenDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? IssueDateTime { get; set; }
    public SslCertificateEntity? Issuer { get; set; }
    public DateTimeOffset? LastSeenDateTime { get; set; }
    public string? SerialNumber { get; set; }
    public string? Sha1 { get; set; }
    public SslCertificateEntity? Subject { get; set; }
    public Host[]? RelatedHosts { get; set; }
}
