using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DomainPostFederationConfigurationParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string DomainsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Domains_DomainsId_FederationConfiguration: return $"/domains/{DomainsId}/federationConfiguration";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum DomainPostFederationConfigurationParameterAuthenticationProtocol
        {
            WsFed,
            Saml,
            UnknownFutureValue,
        }
        public enum DomainPostFederationConfigurationParameterPromptLoginBehavior
        {
            TranslateToFreshPasswordAuthentication,
            NativeSupport,
            Disabled,
            UnknownFutureValue,
        }
        public enum DomainPostFederationConfigurationParameterFederatedIdpMfaBehavior
        {
            AcceptIfMfaDoneByFederatedIdp,
            EnforceMfaByFederatedIdp,
            RejectMfaByFederatedIdp,
            UnknownFutureValue,
        }
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
        public enum ApiPath
        {
            Domains_DomainsId_FederationConfiguration,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? IssuerUri { get; set; }
        public string? MetadataExchangeUri { get; set; }
        public string? SigningCertificate { get; set; }
        public string? PassiveSignInUri { get; set; }
        public DomainPostFederationConfigurationParameterAuthenticationProtocol PreferredAuthenticationProtocol { get; set; }
        public string? ActiveSignInUri { get; set; }
        public string? SignOutUri { get; set; }
        public DomainPostFederationConfigurationParameterPromptLoginBehavior PromptLoginBehavior { get; set; }
        public bool? IsSignedAuthenticationRequestRequired { get; set; }
        public string? NextSigningCertificate { get; set; }
        public SigningCertificateUpdateStatus? SigningCertificateUpdateStatus { get; set; }
        public DomainPostFederationConfigurationParameterFederatedIdpMfaBehavior FederatedIdpMfaBehavior { get; set; }
        public string? Id { get; set; }
    }
    public partial class DomainPostFederationConfigurationResponse : RestApiResponse
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
        public async Task<DomainPostFederationConfigurationResponse> DomainPostFederationConfigurationAsync()
        {
            var p = new DomainPostFederationConfigurationParameter();
            return await this.SendAsync<DomainPostFederationConfigurationParameter, DomainPostFederationConfigurationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-post-federationconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainPostFederationConfigurationResponse> DomainPostFederationConfigurationAsync(CancellationToken cancellationToken)
        {
            var p = new DomainPostFederationConfigurationParameter();
            return await this.SendAsync<DomainPostFederationConfigurationParameter, DomainPostFederationConfigurationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-post-federationconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainPostFederationConfigurationResponse> DomainPostFederationConfigurationAsync(DomainPostFederationConfigurationParameter parameter)
        {
            return await this.SendAsync<DomainPostFederationConfigurationParameter, DomainPostFederationConfigurationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-post-federationconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainPostFederationConfigurationResponse> DomainPostFederationConfigurationAsync(DomainPostFederationConfigurationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainPostFederationConfigurationParameter, DomainPostFederationConfigurationResponse>(parameter, cancellationToken);
        }
    }
}
