using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/passwordcredentialconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class PasswordCredentialConfiguration
    {
        public enum PasswordCredentialConfigurationAppCredentialRestrictionType
        {
            PasswordAddition,
            PasswordLifetime,
            SymmetricKeyAddition,
            SymmetricKeyLifetime,
            CustomPasswordAddition,
            UnknownFutureValue,
        }

        public PasswordCredentialConfigurationAppCredentialRestrictionType RestrictionType { get; set; }
        public string? MaxLifeTime { get; set; }
        public DateTimeOffset? RestrictForAppsCreatedAfterDateTime { get; set; }
    }
}
