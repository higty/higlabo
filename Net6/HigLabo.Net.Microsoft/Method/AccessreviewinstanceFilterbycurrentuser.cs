using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewinstanceFilterbycurrentuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_FilterByCurrentUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_FilterByCurrentUser: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/filterByCurrentUser";
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
    }
    public partial class AccessreviewinstanceFilterbycurrentuserResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/accessreviewinstance?view=graph-rest-1.0
        /// </summary>
        public partial class AccessReviewInstance
        {
            public DateTimeOffset? EndDateTime { get; set; }
            public AccessReviewReviewerScope[]? FallbackReviewers { get; set; }
            public string? Id { get; set; }
            public AccessReviewScope? Scope { get; set; }
            public DateTimeOffset? StartDateTime { get; set; }
            public string? Status { get; set; }
            public AccessReviewReviewerScope[]? Reviewers { get; set; }
        }

        public AccessReviewInstance[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceFilterbycurrentuserResponse> AccessreviewinstanceFilterbycurrentuserAsync()
        {
            var p = new AccessreviewinstanceFilterbycurrentuserParameter();
            return await this.SendAsync<AccessreviewinstanceFilterbycurrentuserParameter, AccessreviewinstanceFilterbycurrentuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceFilterbycurrentuserResponse> AccessreviewinstanceFilterbycurrentuserAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceFilterbycurrentuserParameter();
            return await this.SendAsync<AccessreviewinstanceFilterbycurrentuserParameter, AccessreviewinstanceFilterbycurrentuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceFilterbycurrentuserResponse> AccessreviewinstanceFilterbycurrentuserAsync(AccessreviewinstanceFilterbycurrentuserParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceFilterbycurrentuserParameter, AccessreviewinstanceFilterbycurrentuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceFilterbycurrentuserResponse> AccessreviewinstanceFilterbycurrentuserAsync(AccessreviewinstanceFilterbycurrentuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceFilterbycurrentuserParameter, AccessreviewinstanceFilterbycurrentuserResponse>(parameter, cancellationToken);
        }
    }
}
