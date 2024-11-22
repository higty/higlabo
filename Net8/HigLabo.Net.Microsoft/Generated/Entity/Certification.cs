using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/certification?view=graph-rest-1.0
/// </summary>
public partial class Certification
{
    public string? CertificationDetailsUrl { get; set; }
    public DateTimeOffset? CertificationExpirationDateTime { get; set; }
    public bool? IsCertifiedByMicrosoft { get; set; }
    public bool? IsPublisherAttested { get; set; }
    public DateTimeOffset? LastCertificationDateTime { get; set; }
}
