using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-enrollment-importedwindowsautopilotdeviceidentitystate?view=graph-rest-1.0
    /// </summary>
    public partial class ImportedWindowsAutopilotDeviceIdentityState
    {
        public ImportedWindowsAutopilotDeviceIdentityStateImportedWindowsAutopilotDeviceIdentityImportStatus DeviceImportStatus { get; set; }
        public string DeviceRegistrationId { get; set; }
        public Int32? DeviceErrorCode { get; set; }
        public string DeviceErrorName { get; set; }
    }
}
