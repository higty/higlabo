using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-windowsinformationprotectionproxieddomaincollection?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsInformationProtectionProxiedDomainCollection
    {
        public string DisplayName { get; set; }
        public ProxiedDomain[] ProxiedDomains { get; set; }
    }
}
