using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/networkconnection?view=graph-rest-1.0
    /// </summary>
    public partial class NetworkConnection
    {
        public string ApplicationName { get; set; }
        public string DestinationAddress { get; set; }
        public string DestinationLocation { get; set; }
        public string DestinationDomain { get; set; }
        public string DestinationPort { get; set; }
        public string DestinationUrl { get; set; }
        public NetworkConnectionConnectionDirection Direction { get; set; }
        public DateTimeOffset DomainRegisteredDateTime { get; set; }
        public string LocalDnsName { get; set; }
        public string NatDestinationAddress { get; set; }
        public string NatDestinationPort { get; set; }
        public string NatSourceAddress { get; set; }
        public string NatSourcePort { get; set; }
        public NetworkConnectionSecurityNetworkProtocol Protocol { get; set; }
        public string RiskScore { get; set; }
        public string SourceAddress { get; set; }
        public string SourceLocation { get; set; }
        public string SourcePort { get; set; }
        public NetworkConnectionConnectionStatus Status { get; set; }
        public string UrlParameters { get; set; }
    }
}
