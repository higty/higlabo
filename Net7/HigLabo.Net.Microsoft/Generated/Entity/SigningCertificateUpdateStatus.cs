using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/signingcertificateupdatestatus?view=graph-rest-1.0
    /// </summary>
    public partial class SigningCertificateUpdateStatus
    {
        public string? CertificateUpdateResult { get; set; }
        public DateTimeOffset? LastRunDateTime { get; set; }
    }
}
