using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DomainPostFederationconfigurationParameter : IRestApiParameter
    {
        public enum DomainPostFederationconfigurationParameterAuthenticationProtocol
        {
            WsFed,
            Saml,
            UnknownFutureValue,
        }
        public enum DomainPostFederationconfigurationParameterPromptLoginBehavior
        {
            TranslateToFreshPasswordAuthentication,
            NativeSupport,
            Disabled,
            UnknownFutureValue,
        }
        public enum DomainPostFederationconfigurationParameterFederatedIdpMfaBehavior
        {
            AcceptIfMfaDoneByFederatedIdp,
            EnforceMfaByFederatedIdp,
            RejectMfaByFederatedIdp,
            UnknownFutureValue,
        }
        public enum ApiPath
        {
            Domains_DomainsId_FederationConfiguration,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Domains_DomainsId_FederationConfiguration: return $"/domains/{DomainsId}/federationConfiguration";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? IssuerUri { get; set; }
        public string? MetadataExchangeUri { get; set; }
        public string? SigningCertificate { get; set; }
        public string? PassiveSignInUri { get; set; }
        public DomainPostFederationconfigurationParameterAuthenticationProtocol PreferredAuthenticationProtocol { get; set; }
        public string? ActiveSignInUri { get; set; }
        public string? SignOutUri { get; set; }
        public DomainPostFederationconfigurationParameterPromptLoginBehavior PromptLoginBehavior { get; set; }
        public bool? IsSignedAuthenticationRequestRequired { get; set; }
        public string? NextSigningCertificate { get; set; }
        public SigningCertificateUpdateStatus? SigningCertificateUpdateStatus { get; set; }
        public DomainPostFederationconfigurationParameterFederatedIdpMfaBehavior FederatedIdpMfaBehavior { get; set; }
        public string DomainsId { get; set; }
    }
    public partial class DomainPostFederationconfigurationResponse : RestApiResponse
    {
        public enum InternalDomainFederationFederatedIdpMfaBehavior
        {
            AcceptIfMfaDoneByFederatedIdp,
            EnforceMfaByFederatedIdp,
            RejectMfaByFederatedIdp,
            UnknownFutureValue,
        }
        public enum InternalDomainFederationAuthenticationProtocol
        {
            WsFed,
            Saml,
            UnknownFutureValue,
        }
        public enum InternalDomainFederationPromptLoginBehavior
        {
            TranslateToFreshPasswordAuthentication,
            NativeSupport,
            Disabled,
            UnknownFutureValue,
        }

        public string? ActiveSignInUri { get; set; }
        public string? DisplayName { get; set; }
        public InternalDomainFederationFederatedIdpMfaBehavior FederatedIdpMfaBehavior { get; set; }
        public string? Id { get; set; }
        public bool? IsSignedAuthenticationRequestRequired { get; set; }
        public string? IssuerUri { get; set; }
        public string? MetadataExchangeUri { get; set; }
        public string? NextSigningCertificate { get; set; }
        public string? PassiveSignInUri { get; set; }
        public InternalDomainFederationAuthenticationProtocol PreferredAuthenticationProtocol { get; set; }
        public InternalDomainFederationPromptLoginBehavior PromptLoginBehavior { get; set; }
        public string? SigningCertificate { get; set; }
        public SigningCertificateUpdateStatus? SigningCertificateUpdateStatus { get; set; }
        public string? SignOutUri { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-post-federationconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainPostFederationconfigurationResponse> DomainPostFederationconfigurationAsync()
        {
            var p = new DomainPostFederationconfigurationParameter();
            return await this.SendAsync<DomainPostFederationconfigurationParameter, DomainPostFederationconfigurationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-post-federationconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainPostFederationconfigurationResponse> DomainPostFederationconfigurationAsync(CancellationToken cancellationToken)
        {
            var p = new DomainPostFederationconfigurationParameter();
            return await this.SendAsync<DomainPostFederationconfigurationParameter, DomainPostFederationconfigurationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-post-federationconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainPostFederationconfigurationResponse> DomainPostFederationconfigurationAsync(DomainPostFederationconfigurationParameter parameter)
        {
            return await this.SendAsync<DomainPostFederationconfigurationParameter, DomainPostFederationconfigurationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-post-federationconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainPostFederationconfigurationResponse> DomainPostFederationconfigurationAsync(DomainPostFederationconfigurationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainPostFederationconfigurationParameter, DomainPostFederationconfigurationResponse>(parameter, cancellationToken);
        }
    }
}
