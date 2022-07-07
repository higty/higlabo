using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewinstanceResetdecisionsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_ResetDecisions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_ResetDecisions: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/resetDecisions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string AccessReviewScheduleDefinitionId { get; set; }
        public string AccessReviewInstanceId { get; set; }
    }
    public partial class AccessreviewinstanceResetdecisionsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-resetdecisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceResetdecisionsResponse> AccessreviewinstanceResetdecisionsAsync()
        {
            var p = new AccessreviewinstanceResetdecisionsParameter();
            return await this.SendAsync<AccessreviewinstanceResetdecisionsParameter, AccessreviewinstanceResetdecisionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-resetdecisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceResetdecisionsResponse> AccessreviewinstanceResetdecisionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceResetdecisionsParameter();
            return await this.SendAsync<AccessreviewinstanceResetdecisionsParameter, AccessreviewinstanceResetdecisionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-resetdecisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceResetdecisionsResponse> AccessreviewinstanceResetdecisionsAsync(AccessreviewinstanceResetdecisionsParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceResetdecisionsParameter, AccessreviewinstanceResetdecisionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-resetdecisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceResetdecisionsResponse> AccessreviewinstanceResetdecisionsAsync(AccessreviewinstanceResetdecisionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceResetdecisionsParameter, AccessreviewinstanceResetdecisionsResponse>(parameter, cancellationToken);
        }
    }
}
