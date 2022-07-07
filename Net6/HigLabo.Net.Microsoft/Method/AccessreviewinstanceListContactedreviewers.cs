using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewinstanceListContactedreviewersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_ContactedReviewers,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_ContactedReviewers: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/contactedReviewers";
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
    public partial class AccessreviewinstanceListContactedreviewersResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/accessreviewreviewer?view=graph-rest-1.0
        /// </summary>
        public partial class AccessReviewReviewer
        {
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public string? UserPrincipalName { get; set; }
        }

        public AccessReviewReviewer[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-list-contactedreviewers?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListContactedreviewersResponse> AccessreviewinstanceListContactedreviewersAsync()
        {
            var p = new AccessreviewinstanceListContactedreviewersParameter();
            return await this.SendAsync<AccessreviewinstanceListContactedreviewersParameter, AccessreviewinstanceListContactedreviewersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-list-contactedreviewers?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListContactedreviewersResponse> AccessreviewinstanceListContactedreviewersAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceListContactedreviewersParameter();
            return await this.SendAsync<AccessreviewinstanceListContactedreviewersParameter, AccessreviewinstanceListContactedreviewersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-list-contactedreviewers?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListContactedreviewersResponse> AccessreviewinstanceListContactedreviewersAsync(AccessreviewinstanceListContactedreviewersParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceListContactedreviewersParameter, AccessreviewinstanceListContactedreviewersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-list-contactedreviewers?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceListContactedreviewersResponse> AccessreviewinstanceListContactedreviewersAsync(AccessreviewinstanceListContactedreviewersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceListContactedreviewersParameter, AccessreviewinstanceListContactedreviewersResponse>(parameter, cancellationToken);
        }
    }
}
