
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-manageddevice?view=graph-rest-1.0
    /// </summary>
    public enum ManagedDeviceDeviceManagementExchangeAccessStateReason
    {
        None,
        Unknown,
        ExchangeGlobalRule,
        ExchangeIndividualRule,
        ExchangeDeviceRule,
        ExchangeUpgrade,
        ExchangeMailboxPolicy,
        Other,
        Compliant,
        NotCompliant,
        NotEnrolled,
        UnknownLocation,
        MfaRequired,
        AzureADBlockDueToAccessPolicy,
        CompromisedPassword,
        DeviceNotKnownWithManagedApp,
    }
}
