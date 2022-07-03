using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-proxieddomain?view=graph-rest-1.0
    /// </summary>
    public partial class ProxiedDomain
    {
        public string IpAddressOrFQDN { get; set; }
        public string Proxy { get; set; }
    }
}
