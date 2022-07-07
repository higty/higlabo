using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-macosgeneraldeviceconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class MacOSGeneralDeviceConfiguration
    {
        public enum MacOSGeneralDeviceConfigurationAppListType
        {
            None,
            AppsInListCompliant,
            AppsNotInListCompliant,
        }
        public enum MacOSGeneralDeviceConfigurationRequiredPasswordType
        {
            DeviceDefault,
            Alphanumeric,
            Numeric,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public AppListItem[]? CompliantAppsList { get; set; }
        public AppListType? CompliantAppListType { get; set; }
        public String[]? EmailInDomainSuffixes { get; set; }
        public bool? PasswordBlockSimple { get; set; }
        public Int32? PasswordExpirationDays { get; set; }
        public Int32? PasswordMinimumCharacterSetCount { get; set; }
        public Int32? PasswordMinimumLength { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeLock { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }
        public Int32? PasswordPreviousPasswordBlockCount { get; set; }
        public RequiredPasswordType? PasswordRequiredType { get; set; }
        public bool? PasswordRequired { get; set; }
    }
}
