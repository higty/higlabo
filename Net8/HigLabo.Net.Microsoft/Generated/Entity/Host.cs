using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-host?view=graph-rest-1.0
    /// </summary>
    public partial class Host
    {
        public DateTimeOffset? FirstSeenDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastSeenDateTime { get; set; }
        public HostPair[]? ChildHostPairs { get; set; }
        public HostComponent[]? Components { get; set; }
        public HostCookie[]? Cookies { get; set; }
        public HostPair[]? HostPairs { get; set; }
        public HostPair[]? ParentHostPairs { get; set; }
        public PassiveDnsRecord[]? PassiveDns { get; set; }
        public PassiveDnsRecord[]? PassiveDnsReverse { get; set; }
        public HostPort[]? Ports { get; set; }
        public HostReputation? Reputation { get; set; }
        public HostSslCertificate[]? SslCertificates { get; set; }
        public Subdomain[]? Subdomains { get; set; }
        public HostTracker[]? Trackers { get; set; }
        public WhoisRecord? Whois { get; set; }
    }
}
