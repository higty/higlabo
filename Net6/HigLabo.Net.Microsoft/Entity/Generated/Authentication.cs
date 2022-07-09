using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/authentication?view=graph-rest-1.0
    /// </summary>
    public partial class Authentication
    {
        public Fido2AuthenticationMethod[]? Fido2Methods { get; set; }
        public AuthenticationMethod[]? Methods { get; set; }
        public MicrosoftAuthenticatorAuthenticationMethod[]? MicrosoftAuthenticatorMethods { get; set; }
        public TemporaryAccessPassAuthenticationMethod[]? TemporaryAccessPassMethods { get; set; }
        public WindowsHelloForBusinessAuthenticationMethod[]? WindowsHelloForBusinessMethods { get; set; }
    }
}
