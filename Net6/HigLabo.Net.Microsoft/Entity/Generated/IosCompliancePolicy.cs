using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-ioscompliancepolicy?view=graph-rest-1.0
    /// </summary>
    public partial class IosCompliancePolicy
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string Description { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public string DisplayName { get; set; }
        public Int32? Version { get; set; }
        public bool PasscodeBlockSimple { get; set; }
        public Int32? PasscodeExpirationDays { get; set; }
        public Int32? PasscodeMinimumLength { get; set; }
        public Int32? PasscodeMinutesOfInactivityBeforeLock { get; set; }
        public Int32? PasscodePreviousPasscodeBlockCount { get; set; }
        public Int32? PasscodeMinimumCharacterSetCount { get; set; }
        public IosCompliancePolicyRequiredPasswordType PasscodeRequiredType { get; set; }
        public bool PasscodeRequired { get; set; }
        public string OsMinimumVersion { get; set; }
        public string OsMaximumVersion { get; set; }
        public bool SecurityBlockJailbrokenDevices { get; set; }
        public bool DeviceThreatProtectionEnabled { get; set; }
        public IosCompliancePolicyDeviceThreatProtectionLevel DeviceThreatProtectionRequiredSecurityLevel { get; set; }
        public bool ManagedEmailProfileRequired { get; set; }
    }
}
