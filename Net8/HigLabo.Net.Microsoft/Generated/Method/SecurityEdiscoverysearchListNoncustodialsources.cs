using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-noncustodialsources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverysearchListNoncustodialsourcesParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_NoncustodialSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}/noncustodialSources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_NoncustodialSources,
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
    public partial class SecurityEDiscoverysearchListNoncustodialsourcesResponse : RestApiResponse<EDiscoveryNoncustodialDataSource>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-noncustodialsources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-noncustodialsources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverysearchListNoncustodialsourcesResponse> SecurityEDiscoverysearchListNoncustodialsourcesAsync()
        {
            var p = new SecurityEDiscoverysearchListNoncustodialsourcesParameter();
            return await this.SendAsync<SecurityEDiscoverysearchListNoncustodialsourcesParameter, SecurityEDiscoverysearchListNoncustodialsourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-noncustodialsources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverysearchListNoncustodialsourcesResponse> SecurityEDiscoverysearchListNoncustodialsourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverysearchListNoncustodialsourcesParameter();
            return await this.SendAsync<SecurityEDiscoverysearchListNoncustodialsourcesParameter, SecurityEDiscoverysearchListNoncustodialsourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-noncustodialsources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverysearchListNoncustodialsourcesResponse> SecurityEDiscoverysearchListNoncustodialsourcesAsync(SecurityEDiscoverysearchListNoncustodialsourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverysearchListNoncustodialsourcesParameter, SecurityEDiscoverysearchListNoncustodialsourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-noncustodialsources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverysearchListNoncustodialsourcesResponse> SecurityEDiscoverysearchListNoncustodialsourcesAsync(SecurityEDiscoverysearchListNoncustodialsourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverysearchListNoncustodialsourcesParameter, SecurityEDiscoverysearchListNoncustodialsourcesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-list-noncustodialsources?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<EDiscoveryNoncustodialDataSource> SecurityEDiscoverysearchListNoncustodialsourcesEnumerateAsync(SecurityEDiscoverysearchListNoncustodialsourcesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SecurityEDiscoverysearchListNoncustodialsourcesParameter, SecurityEDiscoverysearchListNoncustodialsourcesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<EDiscoveryNoncustodialDataSource>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
