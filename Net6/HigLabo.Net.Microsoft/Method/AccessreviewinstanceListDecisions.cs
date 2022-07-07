using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewinstanceListDecisionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/decisions";
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
    public partial class AccessreviewinstanceListDecisionsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/accessreviewinstancedecisionitem?view=graph-rest-1.0
        /// </summary>
        public partial class AccessReviewInstanceDecisionItem
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

        public AccessReviewInstanceDecisionItem[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListDecisionsResponse> AccessreviewinstanceListDecisionsAsync()
        {
            var p = new AccessreviewinstanceListDecisionsParameter();
            return await this.SendAsync<AccessreviewinstanceListDecisionsParameter, AccessreviewinstanceListDecisionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListDecisionsResponse> AccessreviewinstanceListDecisionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceListDecisionsParameter();
            return await this.SendAsync<AccessreviewinstanceListDecisionsParameter, AccessreviewinstanceListDecisionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListDecisionsResponse> AccessreviewinstanceListDecisionsAsync(AccessreviewinstanceListDecisionsParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceListDecisionsParameter, AccessreviewinstanceListDecisionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-list-decisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListDecisionsResponse> AccessreviewinstanceListDecisionsAsync(AccessreviewinstanceListDecisionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceListDecisionsParameter, AccessreviewinstanceListDecisionsResponse>(parameter, cancellationToken);
        }
    }
}
