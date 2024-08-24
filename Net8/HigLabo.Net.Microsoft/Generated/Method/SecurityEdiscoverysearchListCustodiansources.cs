using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-custodiansources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverysearchListCustodiansourcesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoverySearchId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_CustodianSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}/custodianSources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_CustodianSources,
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
    public partial class SecurityEDiscoverysearchListCustodiansourcesResponse : RestApiResponse<DataSource>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-custodiansources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverysearchListCustodiansourcesResponse> SecurityEDiscoverysearchListCustodiansourcesAsync()
        {
            var p = new SecurityEDiscoverysearchListCustodiansourcesParameter();
            return await this.SendAsync<SecurityEDiscoverysearchListCustodiansourcesParameter, SecurityEDiscoverysearchListCustodiansourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverysearchListCustodiansourcesResponse> SecurityEDiscoverysearchListCustodiansourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverysearchListCustodiansourcesParameter();
            return await this.SendAsync<SecurityEDiscoverysearchListCustodiansourcesParameter, SecurityEDiscoverysearchListCustodiansourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverysearchListCustodiansourcesResponse> SecurityEDiscoverysearchListCustodiansourcesAsync(SecurityEDiscoverysearchListCustodiansourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverysearchListCustodiansourcesParameter, SecurityEDiscoverysearchListCustodiansourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverysearchListCustodiansourcesResponse> SecurityEDiscoverysearchListCustodiansourcesAsync(SecurityEDiscoverysearchListCustodiansourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverysearchListCustodiansourcesParameter, SecurityEDiscoverysearchListCustodiansourcesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DataSource> SecurityEDiscoverysearchListCustodiansourcesEnumerateAsync(SecurityEDiscoverysearchListCustodiansourcesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SecurityEDiscoverysearchListCustodiansourcesParameter, SecurityEDiscoverysearchListCustodiansourcesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DataSource>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
