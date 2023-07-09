using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/smsauthenticationmethodconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class SmsAuthenticationMethodConfiguration
    {
        public enum SmsAuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public ExcludeTarget[]? ExcludeTargets { get; set; }
        public string? Id { get; set; }
        public SmsAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
        public SmsAuthenticationMethodTarget[]? IncludeTargets { get; set; }
    }
}
