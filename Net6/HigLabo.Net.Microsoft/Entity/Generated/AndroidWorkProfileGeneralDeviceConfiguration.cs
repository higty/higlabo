using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-androidworkprofilegeneraldeviceconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class AndroidWorkProfileGeneralDeviceConfiguration
    {
        public enum AndroidWorkProfileGeneralDeviceConfigurationAndroidWorkProfileRequiredPasswordType
        {
            DeviceDefault,
            LowSecurityBiometric,
            Required,
            AtLeastNumeric,
            NumericComplex,
            AtLeastAlphabetic,
            AtLeastAlphanumeric,
            AlphanumericWithSymbols,
        }
        public enum AndroidWorkProfileGeneralDeviceConfigurationAndroidWorkProfileCrossProfileDataSharingType
        {
            DeviceDefault,
            PreventAny,
            AllowPersonalToWork,
            NoRestrictions,
        }
        public enum AndroidWorkProfileGeneralDeviceConfigurationAndroidWorkProfileDefaultAppPermissionPolicyType
        {
            DeviceDefault,
            Prompt,
            AutoGrant,
            AutoDeny,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public bool? PasswordBlockFingerprintUnlock { get; set; }
        public bool? PasswordBlockTrustAgents { get; set; }
        public Int32? PasswordExpirationDays { get; set; }
        public Int32? PasswordMinimumLength { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }
        public Int32? PasswordPreviousPasswordBlockCount { get; set; }
        public Int32? PasswordSignInFailureCountBeforeFactoryReset { get; set; }
        public AndroidWorkProfileRequiredPasswordType? PasswordRequiredType { get; set; }
        public AndroidWorkProfileCrossProfileDataSharingType? WorkProfileDataSharingType { get; set; }
        public bool? WorkProfileBlockNotificationsWhileDeviceLocked { get; set; }
        public bool? WorkProfileBlockAddingAccounts { get; set; }
        public bool? WorkProfileBluetoothEnableContactSharing { get; set; }
        public bool? WorkProfileBlockScreenCapture { get; set; }
        public bool? WorkProfileBlockCrossProfileCallerId { get; set; }
        public bool? WorkProfileBlockCamera { get; set; }
        public bool? WorkProfileBlockCrossProfileContactsSearch { get; set; }
        public bool? WorkProfileBlockCrossProfileCopyPaste { get; set; }
        public AndroidWorkProfileDefaultAppPermissionPolicyType? WorkProfileDefaultAppPermissionPolicy { get; set; }
        public bool? WorkProfilePasswordBlockFingerprintUnlock { get; set; }
        public bool? WorkProfilePasswordBlockTrustAgents { get; set; }
        public Int32? WorkProfilePasswordExpirationDays { get; set; }
        public Int32? WorkProfilePasswordMinimumLength { get; set; }
        public Int32? WorkProfilePasswordMinNumericCharacters { get; set; }
        public Int32? WorkProfilePasswordMinNonLetterCharacters { get; set; }
        public Int32? WorkProfilePasswordMinLetterCharacters { get; set; }
        public Int32? WorkProfilePasswordMinLowerCaseCharacters { get; set; }
        public Int32? WorkProfilePasswordMinUpperCaseCharacters { get; set; }
        public Int32? WorkProfilePasswordMinSymbolCharacters { get; set; }
        public Int32? WorkProfilePasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }
        public Int32? WorkProfilePasswordPreviousPasswordBlockCount { get; set; }
        public Int32? WorkProfilePasswordSignInFailureCountBeforeFactoryReset { get; set; }
        public AndroidWorkProfileRequiredPasswordType? WorkProfilePasswordRequiredType { get; set; }
        public bool? WorkProfileRequirePassword { get; set; }
        public bool? SecurityRequireVerifyApps { get; set; }
    }
}
