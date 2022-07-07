using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewinstancedecisionitemGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions_AccessReviewInstanceDecisionItemId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions_AccessReviewInstanceDecisionItemId: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/decisions/{AccessReviewInstanceDecisionItemId}";
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
        public string AccessReviewInstanceDecisionItemId { get; set; }
    }
    public partial class AccessreviewinstancedecisionitemGetResponse : RestApiResponse
    {
        public string? AccessReviewId { get; set; }
        public UserIdentity? AppliedBy { get; set; }
        public DateTimeOffset? AppliedDateTime { get; set; }
        public string? ApplyResult { get; set; }
        public string? Decision { get; set; }
        public string? Id { get; set; }
        public string? Justification { get; set; }
        public Identity? Principal { get; set; }
        public string? PrincipalLink { get; set; }
        public string? Recommendation { get; set; }
        public AccessReviewInstanceDecisionItemResource? Resource { get; set; }
        public string? ResourceLink { get; set; }
        public UserIdentity? ReviewedBy { get; set; }
        public DateTimeOffset? ReviewedDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstancedecisionitemGetResponse> AccessreviewinstancedecisionitemGetAsync()
        {
            var p = new AccessreviewinstancedecisionitemGetParameter();
            return await this.SendAsync<AccessreviewinstancedecisionitemGetParameter, AccessreviewinstancedecisionitemGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstancedecisionitemGetResponse> AccessreviewinstancedecisionitemGetAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstancedecisionitemGetParameter();
            return await this.SendAsync<AccessreviewinstancedecisionitemGetParameter, AccessreviewinstancedecisionitemGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstancedecisionitemGetResponse> AccessreviewinstancedecisionitemGetAsync(AccessreviewinstancedecisionitemGetParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstancedecisionitemGetParameter, AccessreviewinstancedecisionitemGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstancedecisionitemGetResponse> AccessreviewinstancedecisionitemGetAsync(AccessreviewinstancedecisionitemGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstancedecisionitemGetParameter, AccessreviewinstancedecisionitemGetResponse>(parameter, cancellationToken);
        }
    }
}
