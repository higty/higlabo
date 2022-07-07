using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-deviceappmanagement?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceAppManagement
    {
        public string? Id { get; set; }
        public DateTimeOffset? MicrosoftStoreForBusinessLastSuccessfulSyncDateTime { get; set; }
        public bool? IsEnabledForMicrosoftStoreForBusiness { get; set; }
        public string? MicrosoftStoreForBusinessLanguage { get; set; }
        public DateTimeOffset? MicrosoftStoreForBusinessLastCompletedApplicationSyncTime { get; set; }
    }
}
