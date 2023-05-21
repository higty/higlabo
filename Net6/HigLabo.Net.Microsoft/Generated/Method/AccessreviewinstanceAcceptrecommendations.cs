using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-acceptrecommendations?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewinstanceAcceptrecommendationsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessReviewScheduleDefinitionId { get; set; }
            public string? AccessReviewInstanceId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_AcceptRecommendations: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/acceptRecommendations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_AcceptRecommendations,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class AccessreviewinstanceAcceptrecommendationsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-acceptrecommendations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-acceptrecommendations?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceAcceptrecommendationsResponse> AccessreviewinstanceAcceptrecommendationsAsync()
        {
            var p = new AccessreviewinstanceAcceptrecommendationsParameter();
            return await this.SendAsync<AccessreviewinstanceAcceptrecommendationsParameter, AccessreviewinstanceAcceptrecommendationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-acceptrecommendations?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceAcceptrecommendationsResponse> AccessreviewinstanceAcceptrecommendationsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceAcceptrecommendationsParameter();
            return await this.SendAsync<AccessreviewinstanceAcceptrecommendationsParameter, AccessreviewinstanceAcceptrecommendationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-acceptrecommendations?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceAcceptrecommendationsResponse> AccessreviewinstanceAcceptrecommendationsAsync(AccessreviewinstanceAcceptrecommendationsParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceAcceptrecommendationsParameter, AccessreviewinstanceAcceptrecommendationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-acceptrecommendations?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceAcceptrecommendationsResponse> AccessreviewinstanceAcceptrecommendationsAsync(AccessreviewinstanceAcceptrecommendationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceAcceptrecommendationsParameter, AccessreviewinstanceAcceptrecommendationsResponse>(parameter, cancellationToken);
        }
    }
}
