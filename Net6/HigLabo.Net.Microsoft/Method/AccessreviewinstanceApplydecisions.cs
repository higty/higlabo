using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewinstanceApplydecisionsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_ApplyDecisions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_ApplyDecisions: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/applyDecisions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string AccessReviewScheduleDefinitionId { get; set; }
        public string AccessReviewInstanceId { get; set; }
    }
    public partial class AccessreviewinstanceApplydecisionsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-applydecisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceApplydecisionsResponse> AccessreviewinstanceApplydecisionsAsync()
        {
            var p = new AccessreviewinstanceApplydecisionsParameter();
            return await this.SendAsync<AccessreviewinstanceApplydecisionsParameter, AccessreviewinstanceApplydecisionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-applydecisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceApplydecisionsResponse> AccessreviewinstanceApplydecisionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceApplydecisionsParameter();
            return await this.SendAsync<AccessreviewinstanceApplydecisionsParameter, AccessreviewinstanceApplydecisionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-applydecisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceApplydecisionsResponse> AccessreviewinstanceApplydecisionsAsync(AccessreviewinstanceApplydecisionsParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceApplydecisionsParameter, AccessreviewinstanceApplydecisionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-applydecisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceApplydecisionsResponse> AccessreviewinstanceApplydecisionsAsync(AccessreviewinstanceApplydecisionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceApplydecisionsParameter, AccessreviewinstanceApplydecisionsResponse>(parameter, cancellationToken);
        }
    }
}
