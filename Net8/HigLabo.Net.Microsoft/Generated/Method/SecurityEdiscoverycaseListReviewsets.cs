using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-reviewsets?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycaseListReviewsetsParameter : IRestApiParameter, IQueryParameterProperty
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
            CreatedBy,
            CreatedDateTime,
            DisplayName,
            Id,
            Queries,
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
    public partial class SecurityEdiscoverycaseListReviewsetsResponse : RestApiResponse
    {
        public EdiscoveryReviewSet[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-reviewsets?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-reviewsets?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListReviewsetsResponse> SecurityEdiscoverycaseListReviewsetsAsync()
        {
            var p = new SecurityEdiscoverycaseListReviewsetsParameter();
            return await this.SendAsync<SecurityEdiscoverycaseListReviewsetsParameter, SecurityEdiscoverycaseListReviewsetsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-reviewsets?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListReviewsetsResponse> SecurityEdiscoverycaseListReviewsetsAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycaseListReviewsetsParameter();
            return await this.SendAsync<SecurityEdiscoverycaseListReviewsetsParameter, SecurityEdiscoverycaseListReviewsetsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-reviewsets?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListReviewsetsResponse> SecurityEdiscoverycaseListReviewsetsAsync(SecurityEdiscoverycaseListReviewsetsParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycaseListReviewsetsParameter, SecurityEdiscoverycaseListReviewsetsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-reviewsets?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListReviewsetsResponse> SecurityEdiscoverycaseListReviewsetsAsync(SecurityEdiscoverycaseListReviewsetsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycaseListReviewsetsParameter, SecurityEdiscoverycaseListReviewsetsResponse>(parameter, cancellationToken);
        }
    }
}
