using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/internaldomainfederation?view=graph-rest-1.0
    /// </summary>
    public partial class InternalDomainFederation
    {
        public string ActiveSignInUri { get; set; }
        public string DisplayName { get; set; }
        public InternalDomainFederationFederatedIdpMfaBehavior FederatedIdpMfaBehavior { get; set; }
        public string Id { get; set; }
        public bool IsSignedAuthenticationRequestRequired { get; set; }
        public string IssuerUri { get; set; }
        public string MetadataExchangeUri { get; set; }
        public string NextSigningCertificate { get; set; }
        public string PassiveSignInUri { get; set; }
        public InternalDomainFederationAuthenticationProtocol PreferredAuthenticationProtocol { get; set; }
        public InternalDomainFederationPromptLoginBehavior PromptLoginBehavior { get; set; }
        public string SigningCertificate { get; set; }
        public SigningCertificateUpdateStatus? SigningCertificateUpdateStatus { get; set; }
        public string SignOutUri { get; set; }
    }
}
