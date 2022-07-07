using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windows10mobilecompliancepolicy?view=graph-rest-1.0
    /// </summary>
    public partial class Windows10MobileCompliancePolicy
    {
        public enum Windows10MobileCompliancePolicyRequiredPasswordType
        {
            DeviceDefault,
            Alphanumeric,
            Numeric,
        }

        public string? Id { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public bool? PasswordRequired { get; set; }
        public bool? PasswordBlockSimple { get; set; }
        public Int32? PasswordMinimumLength { get; set; }
        public Int32? PasswordMinimumCharacterSetCount { get; set; }
        public RequiredPasswordType? PasswordRequiredType { get; set; }
        public Int32? PasswordPreviousPasswordBlockCount { get; set; }
        public Int32? PasswordExpirationDays { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeLock { get; set; }
        public bool? PasswordRequireToUnlockFromIdle { get; set; }
        public string? OsMinimumVersion { get; set; }
        public string? OsMaximumVersion { get; set; }
        public bool? EarlyLaunchAntiMalwareDriverEnabled { get; set; }
        public bool? BitLockerEnabled { get; set; }
        public bool? SecureBootEnabled { get; set; }
        public bool? CodeIntegrityEnabled { get; set; }
        public bool? StorageRequireEncryption { get; set; }
    }
}
