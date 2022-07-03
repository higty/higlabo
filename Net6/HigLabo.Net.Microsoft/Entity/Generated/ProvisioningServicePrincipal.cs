using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/provisioningserviceprincipal?view=graph-rest-1.0
    /// </summary>
    public partial class ProvisioningServicePrincipal
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
