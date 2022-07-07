using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/authenticationmethodsregistrationcampaignincludetarget?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationMethodsRegistrationCampaignIncludeTarget
    {
        public enum AuthenticationMethodsRegistrationCampaignIncludeTargetAuthenticationMethodTargetType
        {
            User,
            Group,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public string? TargetedAuthenticationMethod { get; set; }
        public AuthenticationMethodsRegistrationCampaignIncludeTargetAuthenticationMethodTargetType TargetType { get; set; }
    }
}
