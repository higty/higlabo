using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-updatewindowsdeviceaccountactionparameter?view=graph-rest-1.0
    /// </summary>
    public partial class UpdateWindowsDeviceAccountActionParameter
    {
        public WindowsDeviceAccount? DeviceAccount { get; set; }
        public bool PasswordRotationEnabled { get; set; }
        public bool CalendarSyncEnabled { get; set; }
        public string DeviceAccountEmail { get; set; }
        public string ExchangeServer { get; set; }
        public string SessionInitiationProtocalAddress { get; set; }
    }
}
