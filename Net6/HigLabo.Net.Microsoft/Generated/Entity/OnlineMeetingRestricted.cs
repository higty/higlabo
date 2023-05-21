using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/onlinemeetingrestricted?view=graph-rest-1.0
    /// </summary>
    public partial class OnlineMeetingRestricted
    {
        public enum OnlineMeetingRestrictedOnlineMeetingContentSharingDisabledReason
        {
            WatermarkProtection,
            UnknownFutureValue,
        }
        public enum OnlineMeetingRestrictedOnlineMeetingVideoDisabledReason
        {
            WatermarkProtection,
            UnknownFutureValue,
        }

        public OnlineMeetingRestrictedOnlineMeetingContentSharingDisabledReason ContentSharingDisabled { get; set; }
        public OnlineMeetingRestrictedOnlineMeetingVideoDisabledReason VideoDisabled { get; set; }
    }
}
