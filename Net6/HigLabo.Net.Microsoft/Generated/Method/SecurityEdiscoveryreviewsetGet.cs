using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-get?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoveryreviewsetGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? ReviewSetId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_ReviewSetId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/reviewSets/{ReviewSetId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_ReviewSetId,
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
    public partial class SecurityEdiscoveryreviewsetGetResponse : RestApiResponse
    {
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public EdiscoveryReviewSetQuery[]? Queries { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoveryreviewsetGetResponse> SecurityEdiscoveryreviewsetGetAsync()
        {
            var p = new SecurityEdiscoveryreviewsetGetParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewsetGetParameter, SecurityEdiscoveryreviewsetGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoveryreviewsetGetResponse> SecurityEdiscoveryreviewsetGetAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoveryreviewsetGetParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewsetGetParameter, SecurityEdiscoveryreviewsetGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoveryreviewsetGetResponse> SecurityEdiscoveryreviewsetGetAsync(SecurityEdiscoveryreviewsetGetParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewsetGetParameter, SecurityEdiscoveryreviewsetGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoveryreviewsetGetResponse> SecurityEdiscoveryreviewsetGetAsync(SecurityEdiscoveryreviewsetGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewsetGetParameter, SecurityEdiscoveryreviewsetGetResponse>(parameter, cancellationToken);
        }
    }
}
