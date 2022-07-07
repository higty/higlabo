using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/securityvendorinformation?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityVendorInformation
    {
        public string? Provider { get; set; }
        public string? ProviderVersion { get; set; }
        public string? SubProvider { get; set; }
        public string? Vendor { get; set; }
    }
}
