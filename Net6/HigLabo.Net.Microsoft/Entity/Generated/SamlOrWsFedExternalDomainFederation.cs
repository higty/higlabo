using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/samlorwsfedexternaldomainfederation?view=graph-rest-1.0
    /// </summary>
    public partial class SamlOrWsFedExternalDomainFederation
    {
        public enum SamlOrWsFedExternalDomainFederationAuthenticationProtocol
        {
            WsFed,
            Saml,
            UnknownFutureValue,
        }

        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? IssuerUri { get; set; }
        public string? MetadataExchangeUri { get; set; }
        public string? PassiveSignInUri { get; set; }
        public SamlOrWsFedExternalDomainFederationAuthenticationProtocol PreferredAuthenticationProtocol { get; set; }
        public string? SigningCertificate { get; set; }
    }
}
