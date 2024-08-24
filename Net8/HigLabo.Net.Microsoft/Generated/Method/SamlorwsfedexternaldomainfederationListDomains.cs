using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list-domains?view=graph-rest-1.0
    /// </summary>
    public partial class SamlorwsfedexternaldomainfederationListDomainsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SamlOrWsFedExternalDomainFederationID { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_FederationConfigurations_MicrosoftgraphsamlOrWsFedExternalDomainFederation_SamlOrWsFedExternalDomainFederationID_Domains: return $"/directory/federationConfigurations/microsoft.graph.samlOrWsFedExternalDomainFederation/{SamlOrWsFedExternalDomainFederationID}/domains";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Directory_FederationConfigurations_MicrosoftgraphsamlOrWsFedExternalDomainFederation_SamlOrWsFedExternalDomainFederationID_Domains,
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
    public partial class SamlorwsfedexternaldomainfederationListDomainsResponse : RestApiResponse<ExternalDomainName>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list-domains?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list-domains?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SamlorwsfedexternaldomainfederationListDomainsResponse> SamlorwsfedexternaldomainfederationListDomainsAsync()
        {
            var p = new SamlorwsfedexternaldomainfederationListDomainsParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListDomainsParameter, SamlorwsfedexternaldomainfederationListDomainsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list-domains?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SamlorwsfedexternaldomainfederationListDomainsResponse> SamlorwsfedexternaldomainfederationListDomainsAsync(CancellationToken cancellationToken)
        {
            var p = new SamlorwsfedexternaldomainfederationListDomainsParameter();
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListDomainsParameter, SamlorwsfedexternaldomainfederationListDomainsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list-domains?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SamlorwsfedexternaldomainfederationListDomainsResponse> SamlorwsfedexternaldomainfederationListDomainsAsync(SamlorwsfedexternaldomainfederationListDomainsParameter parameter)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListDomainsParameter, SamlorwsfedexternaldomainfederationListDomainsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list-domains?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SamlorwsfedexternaldomainfederationListDomainsResponse> SamlorwsfedexternaldomainfederationListDomainsAsync(SamlorwsfedexternaldomainfederationListDomainsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SamlorwsfedexternaldomainfederationListDomainsParameter, SamlorwsfedexternaldomainfederationListDomainsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/samlorwsfedexternaldomainfederation-list-domains?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<ExternalDomainName> SamlorwsfedexternaldomainfederationListDomainsEnumerateAsync(SamlorwsfedexternaldomainfederationListDomainsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SamlorwsfedexternaldomainfederationListDomainsParameter, SamlorwsfedexternaldomainfederationListDomainsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<ExternalDomainName>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
