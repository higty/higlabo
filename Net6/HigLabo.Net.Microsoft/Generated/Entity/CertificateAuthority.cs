using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/certificateauthority?view=graph-rest-1.0
    /// </summary>
    public partial class CertificateAuthority
    {
        public string? Certificate { get; set; }
        public string? CertificateRevocationListUrl { get; set; }
        public string? DeltaCertificateRevocationListUrl { get; set; }
        public bool? IsRootAuthority { get; set; }
        public string? Issuer { get; set; }
        public string? IssuerSki { get; set; }
    }
}
