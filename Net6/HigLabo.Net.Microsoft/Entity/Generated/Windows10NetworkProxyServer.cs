using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windows10networkproxyserver?view=graph-rest-1.0
    /// </summary>
    public partial class Windows10NetworkProxyServer
    {
        public string Address { get; set; }
        public String[] Exceptions { get; set; }
        public bool UseForLocalAddresses { get; set; }
    }
}
