
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windowsupdateforbusinessconfiguration?view=graph-rest-1.0
    /// </summary>
    public enum WindowsUpdateForBusinessConfigurationWindowsDeliveryOptimizationMode
    {
        UserDefined,
        HttpOnly,
        HttpWithPeeringNat,
        HttpWithPeeringPrivateGroup,
        HttpWithInternetPeering,
        SimpleDownload,
        BypassMode,
    }
}
