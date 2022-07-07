using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewinstanceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string AccessReviewScheduleDefinitionId { get; set; }
        public string AccessReviewInstanceId { get; set; }
    }
    public partial class AccessreviewinstanceGetResponse : RestApiResponse
    {
        public DateTimeOffset? EndDateTime { get; set; }
        public AccessReviewReviewerScope[]? FallbackReviewers { get; set; }
        public string? Id { get; set; }
        public AccessReviewScope? Scope { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? Status { get; set; }
        public AccessReviewReviewerScope[]? Reviewers { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceGetResponse> AccessreviewinstanceGetAsync()
        {
            var p = new AccessreviewinstanceGetParameter();
            return await this.SendAsync<AccessreviewinstanceGetParameter, AccessreviewinstanceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceGetResponse> AccessreviewinstanceGetAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceGetParameter();
            return await this.SendAsync<AccessreviewinstanceGetParameter, AccessreviewinstanceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceGetResponse> AccessreviewinstanceGetAsync(AccessreviewinstanceGetParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceGetParameter, AccessreviewinstanceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceGetResponse> AccessreviewinstanceGetAsync(AccessreviewinstanceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceGetParameter, AccessreviewinstanceGetResponse>(parameter, cancellationToken);
        }
    }
}
