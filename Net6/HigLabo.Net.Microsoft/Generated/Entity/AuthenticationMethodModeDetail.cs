using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/authenticationmethodmodedetail?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationMethodModeDetail
    {
        public enum AuthenticationMethodModeDetailBaseAuthenticationMethod
        {
            Password,
            Voice,
            HardwareOath,
            SoftwareOath,
            Sms,
            Fido2,
            WindowsHelloForBusiness,
            MicrosoftAuthenticator,
            TemporaryAccessPass,
            Email,
            X509Certificate,
            Federation,
            UnknownFutureValue,
        }

        public AuthenticationMethodModeDetailBaseAuthenticationMethod AuthenticationMethod { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
    }
}
