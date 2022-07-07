using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewinstanceAcceptrecommendationsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_AcceptRecommendations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_AcceptRecommendations: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/acceptRecommendations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string AccessReviewScheduleDefinitionId { get; set; }
        public string AccessReviewInstanceId { get; set; }
    }
    public partial class AccessreviewinstanceAcceptrecommendationsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-acceptrecommendations?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceAcceptrecommendationsResponse> AccessreviewinstanceAcceptrecommendationsAsync()
        {
            var p = new AccessreviewinstanceAcceptrecommendationsParameter();
            return await this.SendAsync<AccessreviewinstanceAcceptrecommendationsParameter, AccessreviewinstanceAcceptrecommendationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-acceptrecommendations?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceAcceptrecommendationsResponse> AccessreviewinstanceAcceptrecommendationsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceAcceptrecommendationsParameter();
            return await this.SendAsync<AccessreviewinstanceAcceptrecommendationsParameter, AccessreviewinstanceAcceptrecommendationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-acceptrecommendations?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceAcceptrecommendationsResponse> AccessreviewinstanceAcceptrecommendationsAsync(AccessreviewinstanceAcceptrecommendationsParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceAcceptrecommendationsParameter, AccessreviewinstanceAcceptrecommendationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-acceptrecommendations?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceAcceptrecommendationsResponse> AccessreviewinstanceAcceptrecommendationsAsync(AccessreviewinstanceAcceptrecommendationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceAcceptrecommendationsParameter, AccessreviewinstanceAcceptrecommendationsResponse>(parameter, cancellationToken);
        }
    }
}
