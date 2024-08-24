using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-hostsslcertificateport?view=graph-rest-1.0
    /// </summary>
    public partial class HostSslCertificatePort
    {
        public DateTimeOffset? FirstSeenDateTime { get; set; }
        public DateTimeOffset? LastSeenDateTime { get; set; }
        public Int32? Port { get; set; }
    }
}
