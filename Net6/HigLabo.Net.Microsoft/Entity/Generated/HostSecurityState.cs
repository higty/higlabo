using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/hostsecuritystate?view=graph-rest-1.0
    /// </summary>
    public partial class HostSecurityState
    {
        public string? Fqdn { get; set; }
        public bool? IsAzureAadJoined { get; set; }
        public bool? IsAzureAadRegistered { get; set; }
        public bool? IsHybridAzureDomainJoined { get; set; }
        public string? NetBiosName { get; set; }
        public string? Os { get; set; }
        public string? PrivateIpAddress { get; set; }
        public string? PublicIpAddress { get; set; }
        public string? RiskScore { get; set; }
    }
}
