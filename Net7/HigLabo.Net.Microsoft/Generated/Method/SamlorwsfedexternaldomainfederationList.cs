using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list?view=graph-rest-1.0
    /// </summary>
    public partial class SamlorwsfedexternaldomainfederationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_FederationConfigurations_GraphsamlOrWsFedExternalDomainFederation: return $"/directory/federationConfigurations/graph.samlOrWsFedExternalDomainFederation";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            Id,
            IssuerUri,
            MetadataExchangeUri,
            PassiveSignInUri,
            PreferredAuthenticationProtocol,
            SigningCertificate,
            Domains,
        }
        public enum ApiPath
        {
            Directory_FederationConfigurations_GraphsamlOrWsFedExternalDomainFederation,
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
    public partial class SamlorwsfedexternaldomainfederationListResponse : RestApiResponse
    {
        public SamlOrWsFedExternalDomainFederation[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SamlorwsfedexternaldomainfederationListResponse> SamlorwsfedexternaldomainfederationListAsync()
        {
            var p = new SamlorwsfedexternaldomainfederationListParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListParameter, SamlorwsfedexternaldomainfederationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SamlorwsfedexternaldomainfederationListResponse> SamlorwsfedexternaldomainfederationListAsync(CancellationToken cancellationToken)
        {
            var p = new SamlorwsfedexternaldomainfederationListParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListParameter, SamlorwsfedexternaldomainfederationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SamlorwsfedexternaldomainfederationListResponse> SamlorwsfedexternaldomainfederationListAsync(SamlorwsfedexternaldomainfederationListParameter parameter)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListParameter, SamlorwsfedexternaldomainfederationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SamlorwsfedexternaldomainfederationListResponse> SamlorwsfedexternaldomainfederationListAsync(SamlorwsfedexternaldomainfederationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListParameter, SamlorwsfedexternaldomainfederationListResponse>(parameter, cancellationToken);
        }
    }
}
