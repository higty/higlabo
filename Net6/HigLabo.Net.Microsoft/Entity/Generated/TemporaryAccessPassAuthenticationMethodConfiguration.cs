using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/temporaryaccesspassauthenticationmethodconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class TemporaryAccessPassAuthenticationMethodConfiguration
    {
        public enum TemporaryAccessPassAuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public int? DefaultLength { get; set; }
        public int? DefaultLifetimeInMinutes { get; set; }
        public string? Id { get; set; }
        public bool? IsUsableOnce { get; set; }
        public int? MinimumLifetimeInMinutes { get; set; }
        public int? MaximumLifetimeInMinutes { get; set; }
        public TemporaryAccessPassAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
        public AuthenticationMethodTarget[]? IncludeTargets { get; set; }
    }
}
