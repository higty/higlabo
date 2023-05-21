using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/provisioningstatusinfo?view=graph-rest-1.0
    /// </summary>
    public partial class ProvisioningStatusInfo
    {
        public enum ProvisioningStatusInfoProvisioningResult
        {
            Success,
            Warning,
            Failure,
            Skipped,
            UnknownFutureValue,
        }

        public ProvisioningErrorInfo? ErrorInfo { get; set; }
        public ProvisioningStatusInfoProvisioningResult Status { get; set; }
    }
}
