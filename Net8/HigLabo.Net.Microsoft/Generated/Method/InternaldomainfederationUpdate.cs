using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/internaldomainfederation-update?view=graph-rest-1.0
    /// </summary>
    public partial class InternaldomainfederationUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DomainsId { get; set; }
            public string? InternalDomainFederationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Domains_DomainsId_FederationConfiguration_InternalDomainFederationId: return $"/domains/{DomainsId}/federationConfiguration/{InternalDomainFederationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum InternaldomainfederationUpdateParameterFederatedIdpMfaBehavior
        {
            AcceptIfMfaDoneByFederatedIdp,
            EnforceMfaByFederatedIdp,
            RejectMfaByFederatedIdp,
            UnknownFutureValue,
        }
        public enum InternaldomainfederationUpdateParameterAuthenticationProtocol
        {
            WsFed,
            Saml,
            UnknownFutureValue,
        }
        public enum InternaldomainfederationUpdateParameterPromptLoginBehavior
        {
            TranslateToFreshPasswordAuthentication,
            NativeSupport,
            Disabled,
            UnknownFutureValue,
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? ActiveSignInUri { get; set; }
        public string? DisplayName { get; set; }
        public InternaldomainfederationUpdateParameterFederatedIdpMfaBehavior FederatedIdpMfaBehavior { get; set; }
        public bool? IsSignedAuthenticationRequestRequired { get; set; }
        public string? IssuerUri { get; set; }
        public string? MetadataExchangeUri { get; set; }
        public string? NextSigningCertificate { get; set; }
        public string? PassiveSignInUri { get; set; }
        public InternaldomainfederationUpdateParameterAuthenticationProtocol PreferredAuthenticationProtocol { get; set; }
        public InternaldomainfederationUpdateParameterPromptLoginBehavior PromptLoginBehavior { get; set; }
        public string? SigningCertificate { get; set; }
        public SigningCertificateUpdateStatus? SigningCertificateUpdateStatus { get; set; }
        public string? SignOutUri { get; set; }
    }
    public partial class InternaldomainfederationUpdateResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/internaldomainfederation-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/internaldomainfederation-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<InternaldomainfederationUpdateResponse> InternaldomainfederationUpdateAsync()
        {
            var p = new InternaldomainfederationUpdateParameter();
            return await this.SendAsync<InternaldomainfederationUpdateParameter, InternaldomainfederationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/internaldomainfederation-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<InternaldomainfederationUpdateResponse> InternaldomainfederationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new InternaldomainfederationUpdateParameter();
            return await this.SendAsync<InternaldomainfederationUpdateParameter, InternaldomainfederationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/internaldomainfederation-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<InternaldomainfederationUpdateResponse> InternaldomainfederationUpdateAsync(InternaldomainfederationUpdateParameter parameter)
        {
            return await this.SendAsync<InternaldomainfederationUpdateParameter, InternaldomainfederationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/internaldomainfederation-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<InternaldomainfederationUpdateResponse> InternaldomainfederationUpdateAsync(InternaldomainfederationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InternaldomainfederationUpdateParameter, InternaldomainfederationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
