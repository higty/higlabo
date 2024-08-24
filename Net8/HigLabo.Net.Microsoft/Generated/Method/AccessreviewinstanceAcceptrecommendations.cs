using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-acceptrecommendations?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewinstanceAcceptrecommendationsParameter : IRestApiParameter
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
    public partial class AccessReviewinstanceAcceptrecommendationsResponse : RestApiResponse
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
        public async ValueTask<AccessReviewinstanceAcceptrecommendationsResponse> AccessReviewinstanceAcceptrecommendationsAsync()
        {
            var p = new AccessReviewinstanceAcceptrecommendationsParameter();
            return await this.SendAsync<AccessReviewinstanceAcceptrecommendationsParameter, AccessReviewinstanceAcceptrecommendationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-acceptrecommendations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstanceAcceptrecommendationsResponse> AccessReviewinstanceAcceptrecommendationsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessReviewinstanceAcceptrecommendationsParameter();
            return await this.SendAsync<AccessReviewinstanceAcceptrecommendationsParameter, AccessReviewinstanceAcceptrecommendationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-acceptrecommendations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstanceAcceptrecommendationsResponse> AccessReviewinstanceAcceptrecommendationsAsync(AccessReviewinstanceAcceptrecommendationsParameter parameter)
        {
            return await this.SendAsync<AccessReviewinstanceAcceptrecommendationsParameter, AccessReviewinstanceAcceptrecommendationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-acceptrecommendations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstanceAcceptrecommendationsResponse> AccessReviewinstanceAcceptrecommendationsAsync(AccessReviewinstanceAcceptrecommendationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessReviewinstanceAcceptrecommendationsParameter, AccessReviewinstanceAcceptrecommendationsResponse>(parameter, cancellationToken);
        }
    }
}
