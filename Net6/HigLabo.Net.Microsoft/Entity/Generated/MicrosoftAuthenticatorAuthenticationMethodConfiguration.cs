using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/microsoftauthenticatorauthenticationmethodconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftAuthenticatorAuthenticationMethodConfiguration
    {
        public enum MicrosoftAuthenticatorAuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public string? Id { get; set; }
        public MicrosoftAuthenticatorAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
    }
}
