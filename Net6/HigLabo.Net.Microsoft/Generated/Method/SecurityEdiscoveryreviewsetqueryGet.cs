using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-get?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoveryreviewsetqueryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoveryReviewSetId { get; set; }
            public string? QueryId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Queries_QueryId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/reviewSets/{EdiscoveryReviewSetId}/queries/{QueryId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Queries_QueryId,
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
    public partial class SecurityEdiscoveryreviewsetqueryGetResponse : RestApiResponse
    {
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Query { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoveryreviewsetqueryGetResponse> SecurityEdiscoveryreviewsetqueryGetAsync()
        {
            var p = new SecurityEdiscoveryreviewsetqueryGetParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewsetqueryGetParameter, SecurityEdiscoveryreviewsetqueryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoveryreviewsetqueryGetResponse> SecurityEdiscoveryreviewsetqueryGetAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoveryreviewsetqueryGetParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewsetqueryGetParameter, SecurityEdiscoveryreviewsetqueryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoveryreviewsetqueryGetResponse> SecurityEdiscoveryreviewsetqueryGetAsync(SecurityEdiscoveryreviewsetqueryGetParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewsetqueryGetParameter, SecurityEdiscoveryreviewsetqueryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoveryreviewsetqueryGetResponse> SecurityEdiscoveryreviewsetqueryGetAsync(SecurityEdiscoveryreviewsetqueryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewsetqueryGetParameter, SecurityEdiscoveryreviewsetqueryGetResponse>(parameter, cancellationToken);
        }
    }
}
