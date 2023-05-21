using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workforceintegration?view=graph-rest-1.0
    /// </summary>
    public partial class WorkforceIntegration
    {
        public enum WorkforceIntegrationWorkforceIntegrationSupportedEntities
        {
            None,
            Shift,
            SwapRequest,
            UserShiftPreferences,
            Openshift,
            OpenShiftRequest,
            OfferShiftRequest,
            UnknownFutureValue,
        }

        public Int32? ApiVersion { get; set; }
        public string? DisplayName { get; set; }
        public WorkforceIntegrationEncryption? Encryption { get; set; }
        public bool? IsActive { get; set; }
        public WorkforceIntegrationWorkforceIntegrationSupportedEntities SupportedEntities { get; set; }
        public string? Url { get; set; }
    }
}
