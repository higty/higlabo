using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/voiceauthenticationmethodtarget?view=graph-rest-1.0
    /// </summary>
    public partial class VoiceAuthenticationMethodTarget
    {
        public enum VoiceAuthenticationMethodTargetAuthenticationMethodTargetType
        {
            Group,
            UnknownFutureValue,
            User,
        }

        public string? Id { get; set; }
        public bool? IsRegistrationRequired { get; set; }
        public VoiceAuthenticationMethodTargetAuthenticationMethodTargetType TargetType { get; set; }
    }
}
