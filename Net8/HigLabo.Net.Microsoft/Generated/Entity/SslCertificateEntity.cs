using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-sslcertificateentity?view=graph-rest-1.0
/// </summary>
public partial class SslCertificateEntity
{
    public PhysicalAddress? Address { get; set; }
    public String[]? AlternateNames { get; set; }
    public string? CommonName { get; set; }
    public string? Email { get; set; }
    public string? GivenName { get; set; }
    public string? OrganizationName { get; set; }
    public string? OrganizationUnitName { get; set; }
    public string? SerialNumber { get; set; }
    public string? Surname { get; set; }
}
