using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-batchrecorddecisions?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewinstanceBatchrecorddecisionsParameter : IRestApiParameter
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
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_BatchRecordDecisions: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/batchRecordDecisions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_BatchRecordDecisions,
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
        public string? Decision { get; set; }
        public string? Justification { get; set; }
        public string? PrincipalId { get; set; }
        public string? ResourceId { get; set; }
    }
    public partial class AccessreviewinstanceBatchrecorddecisionsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-batchrecorddecisions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-batchrecorddecisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewinstanceBatchrecorddecisionsResponse> AccessreviewinstanceBatchrecorddecisionsAsync()
        {
            var p = new AccessreviewinstanceBatchrecorddecisionsParameter();
            return await this.SendAsync<AccessreviewinstanceBatchrecorddecisionsParameter, AccessreviewinstanceBatchrecorddecisionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-batchrecorddecisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewinstanceBatchrecorddecisionsResponse> AccessreviewinstanceBatchrecorddecisionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceBatchrecorddecisionsParameter();
            return await this.SendAsync<AccessreviewinstanceBatchrecorddecisionsParameter, AccessreviewinstanceBatchrecorddecisionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-batchrecorddecisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewinstanceBatchrecorddecisionsResponse> AccessreviewinstanceBatchrecorddecisionsAsync(AccessreviewinstanceBatchrecorddecisionsParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceBatchrecorddecisionsParameter, AccessreviewinstanceBatchrecorddecisionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-batchrecorddecisions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewinstanceBatchrecorddecisionsResponse> AccessreviewinstanceBatchrecorddecisionsAsync(AccessreviewinstanceBatchrecorddecisionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceBatchrecorddecisionsParameter, AccessreviewinstanceBatchrecorddecisionsResponse>(parameter, cancellationToken);
        }
    }
}
