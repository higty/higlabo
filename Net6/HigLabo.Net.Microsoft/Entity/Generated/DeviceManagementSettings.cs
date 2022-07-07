using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicemanagementsettings?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceManagementSettings
    {
        public Int32? DeviceComplianceCheckinThresholdDays { get; set; }
        public bool? IsScheduledActionEnabled { get; set; }
        public bool? SecureByDefault { get; set; }
    }
}
