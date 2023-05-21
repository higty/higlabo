using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/keycredentialconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class KeyCredentialConfiguration
    {
        public enum KeyCredentialConfigurationAppKeyCredentialRestrictionType
        {
            AsymmetricKeyLifetime,
            UnknownFutureValue,
        }

        public KeyCredentialConfigurationAppKeyCredentialRestrictionType RestrictionType { get; set; }
        public string? MaxLifeTime { get; set; }
        public DateTimeOffset? RestrictForAppsCreatedAfterDateTime { get; set; }
    }
}
