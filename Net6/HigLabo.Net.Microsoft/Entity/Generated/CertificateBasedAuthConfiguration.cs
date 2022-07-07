using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/certificatebasedauthconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class CertificateBasedAuthConfiguration
    {
        public CertificateAuthority[]? CertificateAuthorities { get; set; }
        public string? Id { get; set; }
    }
}
