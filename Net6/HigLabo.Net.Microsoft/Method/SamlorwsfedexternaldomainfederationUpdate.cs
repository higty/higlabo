using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SamlorwsfedexternaldomainfederationUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SamlOrWsFedExternalDomainFederationID { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Irectory_FederationConfigurations_GraphsamlOrWsFedExternalDomainFederation_SamlOrWsFedExternalDomainFederationID: return $"/irectory/federationConfigurations/graph.samlOrWsFedExternalDomainFederation/{SamlOrWsFedExternalDomainFederationID}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum SamlorwsfedexternaldomainfederationUpdateParameterAuthenticationProtocol
        {
            WsFed,
            Saml,
        }
        public enum ApiPath
        {
            Irectory_FederationConfigurations_GraphsamlOrWsFedExternalDomainFederation_SamlOrWsFedExternalDomainFederationID,
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
        public string? DisplayName { get; set; }
        public string? IssuerUri { get; set; }
        public string? MetadataExchangeUri { get; set; }
        public string? PassiveSignInUri { get; set; }
        public SamlorwsfedexternaldomainfederationUpdateParameterAuthenticationProtocol PreferredAuthenticationProtocol { get; set; }
        public string? SigningCertificate { get; set; }
    }
    public partial class SamlorwsfedexternaldomainfederationUpdateResponse : RestApiResponse
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
        public ExternalDomainName[]? Domains { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationUpdateResponse> SamlorwsfedexternaldomainfederationUpdateAsync()
        {
            var p = new SamlorwsfedexternaldomainfederationUpdateParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationUpdateParameter, SamlorwsfedexternaldomainfederationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationUpdateResponse> SamlorwsfedexternaldomainfederationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new SamlorwsfedexternaldomainfederationUpdateParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationUpdateParameter, SamlorwsfedexternaldomainfederationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationUpdateResponse> SamlorwsfedexternaldomainfederationUpdateAsync(SamlorwsfedexternaldomainfederationUpdateParameter parameter)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationUpdateParameter, SamlorwsfedexternaldomainfederationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SamlorwsfedexternaldomainfederationUpdateResponse> SamlorwsfedexternaldomainfederationUpdateAsync(SamlorwsfedexternaldomainfederationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationUpdateParameter, SamlorwsfedexternaldomainfederationUpdateResponse>(parameter, cancellationToken);
        }
    }
}
