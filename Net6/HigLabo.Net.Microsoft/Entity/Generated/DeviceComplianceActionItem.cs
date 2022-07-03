using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecomplianceactionitem?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceComplianceActionItem
    {
        public string Id { get; set; }
        public Int32? GracePeriodHours { get; set; }
        public DeviceComplianceActionItemDeviceComplianceActionType ActionType { get; set; }
        public string NotificationTemplateId { get; set; }
        public String[] NotificationMessageCCList { get; set; }
    }
}
