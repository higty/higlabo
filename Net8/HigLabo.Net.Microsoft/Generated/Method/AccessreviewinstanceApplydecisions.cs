using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-applydecisions?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewinstanceApplydecisionsParameter : IRestApiParameter
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
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_ApplyDecisions: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/applyDecisions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_ApplyDecisions,
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
    public partial class AccessReviewinstanceApplydecisionsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-applydecisions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-applydecisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstanceApplydecisionsResponse> AccessReviewinstanceApplydecisionsAsync()
        {
            var p = new AccessReviewinstanceApplydecisionsParameter();
            return await this.SendAsync<AccessReviewinstanceApplydecisionsParameter, AccessReviewinstanceApplydecisionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-applydecisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstanceApplydecisionsResponse> AccessReviewinstanceApplydecisionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessReviewinstanceApplydecisionsParameter();
            return await this.SendAsync<AccessReviewinstanceApplydecisionsParameter, AccessReviewinstanceApplydecisionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-applydecisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstanceApplydecisionsResponse> AccessReviewinstanceApplydecisionsAsync(AccessReviewinstanceApplydecisionsParameter parameter)
        {
            return await this.SendAsync<AccessReviewinstanceApplydecisionsParameter, AccessReviewinstanceApplydecisionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-applydecisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewinstanceApplydecisionsResponse> AccessReviewinstanceApplydecisionsAsync(AccessReviewinstanceApplydecisionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessReviewinstanceApplydecisionsParameter, AccessReviewinstanceApplydecisionsResponse>(parameter, cancellationToken);
        }
    }
}
