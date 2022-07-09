using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/authenticationmethodtarget?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationMethodTarget
    {
        public enum AuthenticationMethodTargetAuthenticationMethodTargetType
        {
            User,
            Group,
        }

        public string? Id { get; set; }
        public bool? IsRegistrationRequired { get; set; }
        public AuthenticationMethodTargetAuthenticationMethodTargetType TargetType { get; set; }
        public bool? UseForSignIn { get; set; }
    }
}
