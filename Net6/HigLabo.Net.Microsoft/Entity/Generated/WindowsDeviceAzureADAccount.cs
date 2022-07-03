using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-windowsdeviceazureadaccount?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsDeviceAzureADAccount
    {
        public string Password { get; set; }
        public string UserPrincipalName { get; set; }
    }
}
