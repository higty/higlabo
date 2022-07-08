using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class InternaldomainfederationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string DomainsId { get; set; }
            public string InternalDomainFederationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Domains_DomainsId_FederationConfiguration_InternalDomainFederationId: return $"/domains/{DomainsId}/federationConfiguration/{InternalDomainFederationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Domains_DomainsId_FederationConfiguration_InternalDomainFederationId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class InternaldomainfederationGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/internaldomainfederation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<InternaldomainfederationGetResponse> InternaldomainfederationGetAsync()
        {
            var p = new InternaldomainfederationGetParameter();
            return await this.SendAsync<InternaldomainfederationGetParameter, InternaldomainfederationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/internaldomainfederation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<InternaldomainfederationGetResponse> InternaldomainfederationGetAsync(CancellationToken cancellationToken)
        {
            var p = new InternaldomainfederationGetParameter();
            return await this.SendAsync<InternaldomainfederationGetParameter, InternaldomainfederationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/internaldomainfederation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<InternaldomainfederationGetResponse> InternaldomainfederationGetAsync(InternaldomainfederationGetParameter parameter)
        {
            return await this.SendAsync<InternaldomainfederationGetParameter, InternaldomainfederationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/internaldomainfederation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<InternaldomainfederationGetResponse> InternaldomainfederationGetAsync(InternaldomainfederationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InternaldomainfederationGetParameter, InternaldomainfederationGetResponse>(parameter, cancellationToken);
        }
    }
}
