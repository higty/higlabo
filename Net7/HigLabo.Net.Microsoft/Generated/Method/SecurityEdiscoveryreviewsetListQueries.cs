using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-list-queries?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoveryreviewsetListQueriesParameter : IRestApiParameter, IQueryParameterProperty
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
            CreatedBy,
            CreatedDateTime,
            DisplayName,
            Id,
            LastModifiedBy,
            LastModifiedDateTime,
            Query,
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
    public partial class SecurityEdiscoveryreviewsetListQueriesResponse : RestApiResponse
    {
        public EdiscoveryReviewSetQuery[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-list-queries?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-list-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetListQueriesResponse> SecurityEdiscoveryreviewsetListQueriesAsync()
        {
            var p = new SecurityEdiscoveryreviewsetListQueriesParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewsetListQueriesParameter, SecurityEdiscoveryreviewsetListQueriesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-list-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetListQueriesResponse> SecurityEdiscoveryreviewsetListQueriesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoveryreviewsetListQueriesParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewsetListQueriesParameter, SecurityEdiscoveryreviewsetListQueriesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-list-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetListQueriesResponse> SecurityEdiscoveryreviewsetListQueriesAsync(SecurityEdiscoveryreviewsetListQueriesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewsetListQueriesParameter, SecurityEdiscoveryreviewsetListQueriesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-list-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetListQueriesResponse> SecurityEdiscoveryreviewsetListQueriesAsync(SecurityEdiscoveryreviewsetListQueriesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewsetListQueriesParameter, SecurityEdiscoveryreviewsetListQueriesResponse>(parameter, cancellationToken);
        }
    }
}
