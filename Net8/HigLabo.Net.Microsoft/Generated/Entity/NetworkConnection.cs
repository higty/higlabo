using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/networkconnection?view=graph-rest-1.0
    /// </summary>
    public partial class NetworkConnection
    {
        public enum NetworkConnectionConnectionDirection
        {
            Unknown,
            Inbound,
            Outbound,
        }
        public enum NetworkConnectionSecurityNetworkProtocol
        {
            Unknown,
            Ip,
            Icmp,
            Igmp,
            Ggp,
            Ipv4,
            Tcp,
            Pup,
            Udp,
            Idp,
            Ipv6,
            Ipv6RoutingHeader,
            Ipv6FragmentHeader,
            IpSecEncapsulatingSecurityPayload,
            IpSecAuthenticationHeader,
            IcmpV6,
            Ipv6NoNextHeader,
            Ipv6DestinationOptions,
            Nd,
            Raw,
            Ipx,
            Spx,
            SpxII,
        }
        public enum NetworkConnectionConnectionStatus
        {
            Unknown,
            Attempted,
            Succeeded,
            Blocked,
            Failed,
        }

        public string? ApplicationName { get; set; }
        public string? DestinationAddress { get; set; }
        public string? DestinationDomain { get; set; }
        public string? DestinationLocation { get; set; }
        public string? DestinationPort { get; set; }
        public string? DestinationUrl { get; set; }
        public NetworkConnectionConnectionDirection Direction { get; set; }
        public DateTimeOffset? DomainRegisteredDateTime { get; set; }
        public string? LocalDnsName { get; set; }
        public string? NatDestinationAddress { get; set; }
        public string? NatDestinationPort { get; set; }
        public string? NatSourceAddress { get; set; }
        public string? NatSourcePort { get; set; }
        public SecurityNetworkProtocol? Protocol { get; set; }
        public string? RiskScore { get; set; }
        public string? SourceAddress { get; set; }
        public string? SourceLocation { get; set; }
        public string? SourcePort { get; set; }
        public NetworkConnectionConnectionStatus Status { get; set; }
        public string? UrlParameters { get; set; }
    }
}
