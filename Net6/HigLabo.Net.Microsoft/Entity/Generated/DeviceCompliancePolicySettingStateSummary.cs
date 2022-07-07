using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecompliancepolicysettingstatesummary?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceCompliancePolicySettingStateSummary
    {
        public enum DeviceCompliancePolicySettingStateSummaryPolicyPlatformType
        {
            Android,
            IOS,
            MacOS,
            WindowsPhone81,
            Windows81AndLater,
            Windows10AndLater,
            AndroidWorkProfile,
            All,
        }

        public string? Id { get; set; }
        public string? Setting { get; set; }
        public string? SettingName { get; set; }
        public PolicyPlatformType? PlatformType { get; set; }
        public Int32? UnknownDeviceCount { get; set; }
        public Int32? NotApplicableDeviceCount { get; set; }
        public Int32? CompliantDeviceCount { get; set; }
        public Int32? RemediatedDeviceCount { get; set; }
        public Int32? NonCompliantDeviceCount { get; set; }
        public Int32? ErrorDeviceCount { get; set; }
        public Int32? ConflictDeviceCount { get; set; }
    }
}
