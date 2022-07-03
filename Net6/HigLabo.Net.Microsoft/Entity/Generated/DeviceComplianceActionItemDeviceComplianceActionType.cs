
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecomplianceactionitem?view=graph-rest-1.0
    /// </summary>
    public enum DeviceComplianceActionItemDeviceComplianceActionType
    {
        NoAction,
        Notification,
        Block,
        Retire,
        Wipe,
        RemoveResourceAccessProfiles,
        PushNotification,
    }
}
