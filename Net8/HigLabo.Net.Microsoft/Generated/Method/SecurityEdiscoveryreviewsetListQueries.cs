using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-list-queries?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoveryReviewsetListQueriesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoveryReviewSetId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Queries: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/reviewSets/{EdiscoveryReviewSetId}/queries";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Queries,
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
    public partial class SecurityEDiscoveryReviewsetListQueriesResponse : RestApiResponse<EDiscoveryReviewSetQuery>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-list-queries?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-list-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoveryReviewsetListQueriesResponse> SecurityEDiscoveryReviewsetListQueriesAsync()
        {
            var p = new SecurityEDiscoveryReviewsetListQueriesParameter();
            return await this.SendAsync<SecurityEDiscoveryReviewsetListQueriesParameter, SecurityEDiscoveryReviewsetListQueriesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-list-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoveryReviewsetListQueriesResponse> SecurityEDiscoveryReviewsetListQueriesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoveryReviewsetListQueriesParameter();
            return await this.SendAsync<SecurityEDiscoveryReviewsetListQueriesParameter, SecurityEDiscoveryReviewsetListQueriesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-list-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoveryReviewsetListQueriesResponse> SecurityEDiscoveryReviewsetListQueriesAsync(SecurityEDiscoveryReviewsetListQueriesParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoveryReviewsetListQueriesParameter, SecurityEDiscoveryReviewsetListQueriesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-list-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoveryReviewsetListQueriesResponse> SecurityEDiscoveryReviewsetListQueriesAsync(SecurityEDiscoveryReviewsetListQueriesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoveryReviewsetListQueriesParameter, SecurityEDiscoveryReviewsetListQueriesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-list-queries?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<EDiscoveryReviewSetQuery> SecurityEDiscoveryReviewsetListQueriesEnumerateAsync(SecurityEDiscoveryReviewsetListQueriesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SecurityEDiscoveryReviewsetListQueriesParameter, SecurityEDiscoveryReviewsetListQueriesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<EDiscoveryReviewSetQuery>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
