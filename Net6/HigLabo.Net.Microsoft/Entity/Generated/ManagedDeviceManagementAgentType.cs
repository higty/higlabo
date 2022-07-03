
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-manageddevice?view=graph-rest-1.0
    /// </summary>
    public enum ManagedDeviceManagementAgentType
    {
        Eas,
        Mdm,
        EasMdm,
        IntuneClient,
        EasIntuneClient,
        ConfigurationManagerClient,
        ConfigurationManagerClientMdm,
        ConfigurationManagerClientMdmEas,
        Unknown,
        Jamf,
        GoogleCloudDevicePolicyController,
    }
}
