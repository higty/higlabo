using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewinstancedecisionitemFilterbycurrentuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions_FilterByCurrentUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Decisions_FilterByCurrentUser: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/decisions/filterByCurrentUser";
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
    public partial class AccessreviewinstancedecisionitemFilterbycurrentuserResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstancedecisionitemFilterbycurrentuserResponse> AccessreviewinstancedecisionitemFilterbycurrentuserAsync()
        {
            var p = new AccessreviewinstancedecisionitemFilterbycurrentuserParameter();
            return await this.SendAsync<AccessreviewinstancedecisionitemFilterbycurrentuserParameter, AccessreviewinstancedecisionitemFilterbycurrentuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstancedecisionitemFilterbycurrentuserResponse> AccessreviewinstancedecisionitemFilterbycurrentuserAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstancedecisionitemFilterbycurrentuserParameter();
            return await this.SendAsync<AccessreviewinstancedecisionitemFilterbycurrentuserParameter, AccessreviewinstancedecisionitemFilterbycurrentuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstancedecisionitemFilterbycurrentuserResponse> AccessreviewinstancedecisionitemFilterbycurrentuserAsync(AccessreviewinstancedecisionitemFilterbycurrentuserParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstancedecisionitemFilterbycurrentuserParameter, AccessreviewinstancedecisionitemFilterbycurrentuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstancedecisionitem-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstancedecisionitemFilterbycurrentuserResponse> AccessreviewinstancedecisionitemFilterbycurrentuserAsync(AccessreviewinstancedecisionitemFilterbycurrentuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstancedecisionitemFilterbycurrentuserParameter, AccessreviewinstancedecisionitemFilterbycurrentuserResponse>(parameter, cancellationToken);
        }
    }
}
