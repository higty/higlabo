using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-applydecisions?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewinstanceApplydecisionsParameter : IRestApiParameter
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
    public partial class AccessreviewinstanceApplydecisionsResponse : RestApiResponse
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
        public async ValueTask<AccessreviewinstanceApplydecisionsResponse> AccessreviewinstanceApplydecisionsAsync()
        {
            var p = new AccessreviewinstanceApplydecisionsParameter();
            return await this.SendAsync<AccessreviewinstanceApplydecisionsParameter, AccessreviewinstanceApplydecisionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-applydecisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewinstanceApplydecisionsResponse> AccessreviewinstanceApplydecisionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceApplydecisionsParameter();
            return await this.SendAsync<AccessreviewinstanceApplydecisionsParameter, AccessreviewinstanceApplydecisionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-applydecisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewinstanceApplydecisionsResponse> AccessreviewinstanceApplydecisionsAsync(AccessreviewinstanceApplydecisionsParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceApplydecisionsParameter, AccessreviewinstanceApplydecisionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-applydecisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewinstanceApplydecisionsResponse> AccessreviewinstanceApplydecisionsAsync(AccessreviewinstanceApplydecisionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceApplydecisionsParameter, AccessreviewinstanceApplydecisionsResponse>(parameter, cancellationToken);
        }
    }
}
