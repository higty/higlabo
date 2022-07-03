using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/provisioningstatusinfo?view=graph-rest-1.0
    /// </summary>
    public partial class ProvisioningStatusInfo
    {
        public ProvisioningStatusInfoProvisioningResult Status { get; set; }
        public ProvisioningErrorInfo? ErrorInfo { get; set; }
    }
}
