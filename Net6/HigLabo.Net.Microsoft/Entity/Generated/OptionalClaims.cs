using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/optionalclaims?view=graph-rest-1.0
    /// </summary>
    public partial class OptionalClaims
    {
        public OptionalClaim[] IdToken { get; set; }
        public OptionalClaim[] AccessToken { get; set; }
        public OptionalClaim[] Saml2Token { get; set; }
    }
}
