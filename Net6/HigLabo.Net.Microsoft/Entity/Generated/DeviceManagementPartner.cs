using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-devicemanagementpartner?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceManagementPartner
    {
        public enum DeviceManagementPartnerDeviceManagementPartnerTenantState
        {
            Unknown,
            Unavailable,
            Enabled,
            Terminated,
            Rejected,
            Unresponsive,
        }
        public enum DeviceManagementPartnerDeviceManagementPartnerAppType
        {
            Unknown,
            SingleTenantApp,
            MultiTenantApp,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastHeartbeatDateTime { get; set; }
        public DeviceManagementPartnerTenantState? PartnerState { get; set; }
        public DeviceManagementPartnerAppType? PartnerAppType { get; set; }
        public string? SingleTenantAppId { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsConfigured { get; set; }
        public DateTimeOffset? WhenPartnerDevicesWillBeRemovedDateTime { get; set; }
        public DateTimeOffset? WhenPartnerDevicesWillBeMarkedAsNonCompliantDateTime { get; set; }
    }
}
