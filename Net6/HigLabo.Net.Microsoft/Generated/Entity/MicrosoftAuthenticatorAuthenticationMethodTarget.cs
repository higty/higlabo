using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/microsoftauthenticatorauthenticationmethodtarget?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftAuthenticatorAuthenticationMethodTarget
    {
        public enum MicrosoftAuthenticatorAuthenticationMethodTargetMicrosoftAuthenticatorAuthenticationMode
        {
            Any,
            DeviceBasedPush,
            Push,
        }
        public enum MicrosoftAuthenticatorAuthenticationMethodTargetAuthenticationMethodTargetType
        {
            User,
            Group,
        }

        public MicrosoftAuthenticatorAuthenticationMethodTargetMicrosoftAuthenticatorAuthenticationMode AuthenticationMode { get; set; }
        public string? Id { get; set; }
        public bool? IsRegistrationRequired { get; set; }
        public MicrosoftAuthenticatorAuthenticationMethodTargetAuthenticationMethodTargetType TargetType { get; set; }
    }
}
