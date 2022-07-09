using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/provisioningerrorinfo?view=graph-rest-1.0
    /// </summary>
    public partial class ProvisioningErrorInfo
    {
        public enum ProvisioningErrorInfoProvisioningStatusErrorCategory
        {
            Failure,
            NonServiceFailure,
            Success,
            UnknownFutureValue,
        }

        public string? AdditionalDetails { get; set; }
        public ProvisioningErrorInfoProvisioningStatusErrorCategory ErrorCategory { get; set; }
        public string? ErrorCode { get; set; }
        public string? Reason { get; set; }
        public string? RecommendedAction { get; set; }
    }
}
