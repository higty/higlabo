using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-enrollment-importedwindowsautopilotdeviceidentity?view=graph-rest-1.0
    /// </summary>
    public partial class ImportedWindowsAutopilotDeviceIdentity
    {
        public string Id { get; set; }
        public string GroupTag { get; set; }
        public string SerialNumber { get; set; }
        public string ProductKey { get; set; }
        public string ImportId { get; set; }
        public string HardwareIdentifier { get; set; }
        public ImportedWindowsAutopilotDeviceIdentityState? State { get; set; }
        public string AssignedUserPrincipalName { get; set; }
    }
}
