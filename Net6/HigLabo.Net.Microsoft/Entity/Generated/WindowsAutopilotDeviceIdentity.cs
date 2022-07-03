using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-enrollment-windowsautopilotdeviceidentity?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsAutopilotDeviceIdentity
    {
        public string Id { get; set; }
        public string GroupTag { get; set; }
        public string PurchaseOrderIdentifier { get; set; }
        public string SerialNumber { get; set; }
        public string ProductKey { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public WindowsAutopilotDeviceIdentityEnrollmentState EnrollmentState { get; set; }
        public DateTimeOffset LastContactedDateTime { get; set; }
        public string AddressableUserName { get; set; }
        public string UserPrincipalName { get; set; }
        public string ResourceName { get; set; }
        public string SkuNumber { get; set; }
        public string SystemFamily { get; set; }
        public string AzureActiveDirectoryDeviceId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DisplayName { get; set; }
    }
}
