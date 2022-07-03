using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-windowsdeviceadaccount?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsDeviceADAccount
    {
        public string Password { get; set; }
        public string DomainName { get; set; }
        public string UserName { get; set; }
    }
}
