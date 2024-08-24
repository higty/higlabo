using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcrestorepointsetting?view=graph-rest-1.0
    /// </summary>
    public partial class CloudPcReStorePointSetting
    {
        public enum CloudPcReStorePointSettingCloudPcRestorePointFrequencyType
        {
            Default,
            FourHours,
            SixHours,
            TwelveHours,
            SixteenHours,
            TwentyFourHours,
            UnknownFutureValue,
        }

        public CloudPcReStorePointSetting? FrequencyType { get; set; }
        public bool? UserRestoreEnabled { get; set; }
    }
}
