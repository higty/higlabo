using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-devicehealthattestationstate?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceHealthAttestationState
    {
        public string LastUpdateDateTime { get; set; }
        public string ContentNamespaceUrl { get; set; }
        public string DeviceHealthAttestationStatus { get; set; }
        public string ContentVersion { get; set; }
        public DateTimeOffset IssuedDateTime { get; set; }
        public string AttestationIdentityKey { get; set; }
        public Int64? ResetCount { get; set; }
        public Int64? RestartCount { get; set; }
        public string DataExcutionPolicy { get; set; }
        public string BitLockerStatus { get; set; }
        public string BootManagerVersion { get; set; }
        public string CodeIntegrityCheckVersion { get; set; }
        public string SecureBoot { get; set; }
        public string BootDebugging { get; set; }
        public string OperatingSystemKernelDebugging { get; set; }
        public string CodeIntegrity { get; set; }
        public string TestSigning { get; set; }
        public string SafeMode { get; set; }
        public string WindowsPE { get; set; }
        public string EarlyLaunchAntiMalwareDriverProtection { get; set; }
        public string VirtualSecureMode { get; set; }
        public string PcrHashAlgorithm { get; set; }
        public string BootAppSecurityVersion { get; set; }
        public string BootManagerSecurityVersion { get; set; }
        public string TpmVersion { get; set; }
        public string Pcr0 { get; set; }
        public string SecureBootConfigurationPolicyFingerPrint { get; set; }
        public string CodeIntegrityPolicy { get; set; }
        public string BootRevisionListInfo { get; set; }
        public string OperatingSystemRevListInfo { get; set; }
        public string HealthStatusMismatchInfo { get; set; }
        public string HealthAttestationSupportedStatus { get; set; }
    }
}
