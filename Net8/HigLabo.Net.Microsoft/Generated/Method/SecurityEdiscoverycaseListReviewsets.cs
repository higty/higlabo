using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-reviewsets?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverycaseListReviewsetsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/reviewSets";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets,
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
    public partial class SecurityEDiscoverycaseListReviewsetsResponse : RestApiResponse<EDiscoveryReviewSet>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-reviewsets?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-reviewsets?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListReviewsetsResponse> SecurityEDiscoverycaseListReviewsetsAsync()
        {
            var p = new SecurityEDiscoverycaseListReviewsetsParameter();
            return await this.SendAsync<SecurityEDiscoverycaseListReviewsetsParameter, SecurityEDiscoverycaseListReviewsetsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-reviewsets?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListReviewsetsResponse> SecurityEDiscoverycaseListReviewsetsAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverycaseListReviewsetsParameter();
            return await this.SendAsync<SecurityEDiscoverycaseListReviewsetsParameter, SecurityEDiscoverycaseListReviewsetsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-reviewsets?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListReviewsetsResponse> SecurityEDiscoverycaseListReviewsetsAsync(SecurityEDiscoverycaseListReviewsetsParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverycaseListReviewsetsParameter, SecurityEDiscoverycaseListReviewsetsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-reviewsets?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListReviewsetsResponse> SecurityEDiscoverycaseListReviewsetsAsync(SecurityEDiscoverycaseListReviewsetsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverycaseListReviewsetsParameter, SecurityEDiscoverycaseListReviewsetsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-reviewsets?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<EDiscoveryReviewSet> SecurityEDiscoverycaseListReviewsetsEnumerateAsync(SecurityEDiscoverycaseListReviewsetsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SecurityEDiscoverycaseListReviewsetsParameter, SecurityEDiscoverycaseListReviewsetsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<EDiscoveryReviewSet>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
