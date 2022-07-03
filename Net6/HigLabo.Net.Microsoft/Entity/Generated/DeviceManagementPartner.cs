using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-devicemanagementpartner?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceManagementPartner
    {
        public string Id { get; set; }
        public DateTimeOffset LastHeartbeatDateTime { get; set; }
        public DeviceManagementPartnerDeviceManagementPartnerTenantState PartnerState { get; set; }
        public DeviceManagementPartnerDeviceManagementPartnerAppType PartnerAppType { get; set; }
        public string SingleTenantAppId { get; set; }
        public string DisplayName { get; set; }
        public bool IsConfigured { get; set; }
        public DateTimeOffset WhenPartnerDevicesWillBeRemovedDateTime { get; set; }
        public DateTimeOffset WhenPartnerDevicesWillBeMarkedAsNonCompliantDateTime { get; set; }
    }
}
