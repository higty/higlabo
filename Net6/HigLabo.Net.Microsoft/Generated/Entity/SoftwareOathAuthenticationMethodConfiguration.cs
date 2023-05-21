using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/softwareoathauthenticationmethodconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class SoftwareOathAuthenticationMethodConfiguration
    {
        public enum SoftwareOathAuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public ExcludeTarget[]? ExcludeTargets { get; set; }
        public string? Id { get; set; }
        public SoftwareOathAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
        public AuthenticationMethodTarget[]? IncludeTargets { get; set; }
    }
}
