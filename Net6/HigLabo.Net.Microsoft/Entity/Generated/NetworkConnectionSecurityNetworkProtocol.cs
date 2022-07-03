
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/networkconnection?view=graph-rest-1.0
    /// </summary>
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
}
