using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-deviceenrollmentwindowshelloforbusinessconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceEnrollmentWindowsHelloForBusinessConfiguration
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public Int32? Priority { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public Int32? Version { get; set; }
        public Int32? PinMinimumLength { get; set; }
        public Int32? PinMaximumLength { get; set; }
        public DeviceEnrollmentWindowsHelloForBusinessConfigurationWindowsHelloForBusinessPinUsage PinUppercaseCharactersUsage { get; set; }
        public DeviceEnrollmentWindowsHelloForBusinessConfigurationWindowsHelloForBusinessPinUsage PinLowercaseCharactersUsage { get; set; }
        public DeviceEnrollmentWindowsHelloForBusinessConfigurationWindowsHelloForBusinessPinUsage PinSpecialCharactersUsage { get; set; }
        public DeviceEnrollmentWindowsHelloForBusinessConfigurationEnablement State { get; set; }
        public bool SecurityDeviceRequired { get; set; }
        public bool UnlockWithBiometricsEnabled { get; set; }
        public bool RemotePassportEnabled { get; set; }
        public Int32? PinPreviousBlockCount { get; set; }
        public Int32? PinExpirationInDays { get; set; }
        public DeviceEnrollmentWindowsHelloForBusinessConfigurationEnablement EnhancedBiometricsState { get; set; }
    }
}
