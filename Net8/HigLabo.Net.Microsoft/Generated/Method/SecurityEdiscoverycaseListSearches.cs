using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-searches?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverycaseListSearchesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches,
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
    public partial class SecurityEDiscoverycaseListSearchesResponse : RestApiResponse<EDiscoverySearch>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-searches?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-searches?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListSearchesResponse> SecurityEDiscoverycaseListSearchesAsync()
        {
            var p = new SecurityEDiscoverycaseListSearchesParameter();
            return await this.SendAsync<SecurityEDiscoverycaseListSearchesParameter, SecurityEDiscoverycaseListSearchesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-searches?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListSearchesResponse> SecurityEDiscoverycaseListSearchesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverycaseListSearchesParameter();
            return await this.SendAsync<SecurityEDiscoverycaseListSearchesParameter, SecurityEDiscoverycaseListSearchesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-searches?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListSearchesResponse> SecurityEDiscoverycaseListSearchesAsync(SecurityEDiscoverycaseListSearchesParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverycaseListSearchesParameter, SecurityEDiscoverycaseListSearchesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-searches?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListSearchesResponse> SecurityEDiscoverycaseListSearchesAsync(SecurityEDiscoverycaseListSearchesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverycaseListSearchesParameter, SecurityEDiscoverycaseListSearchesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-searches?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<EDiscoverySearch> SecurityEDiscoverycaseListSearchesEnumerateAsync(SecurityEDiscoverycaseListSearchesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SecurityEDiscoverycaseListSearchesParameter, SecurityEDiscoverycaseListSearchesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<EDiscoverySearch>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
