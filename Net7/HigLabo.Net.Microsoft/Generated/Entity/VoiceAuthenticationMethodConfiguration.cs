using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/voiceauthenticationmethodconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class VoiceAuthenticationMethodConfiguration
    {
        public enum VoiceAuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public ExcludeTarget[]? ExcludeTargets { get; set; }
        public string? Id { get; set; }
        public bool? IsOfficePhoneAllowed { get; set; }
        public VoiceAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
        public VoiceAuthenticationMethodTarget[]? IncludeTargets { get; set; }
    }
}
