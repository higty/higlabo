using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/phoneauthenticationmethod?view=graph-rest-1.0
    /// </summary>
    public partial class PhoneAuthenticationMethod
    {
        public enum PhoneAuthenticationMethodAuthenticationPhoneType
        {
            Mobile,
            AlternateMobile,
            Office,
        }
        public enum PhoneAuthenticationMethodAuthenticationMethodSignInState
        {
            NotSupported,
            NotAllowedByPolicy,
            NotEnabled,
            PhoneNumberNotUnique,
            Ready,
            NotConfigured,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public string? PhoneNumber { get; set; }
        public PhoneAuthenticationMethodAuthenticationPhoneType PhoneType { get; set; }
        public PhoneAuthenticationMethodAuthenticationMethodSignInState SmsSignInState { get; set; }
    }
}
