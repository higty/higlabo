using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewinstanceBatchrecorddecisionsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_BatchRecordDecisions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_BatchRecordDecisions: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/batchRecordDecisions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Decision { get; set; }
        public string? Justification { get; set; }
        public string? PrincipalId { get; set; }
        public string? ResourceId { get; set; }
        public string AccessReviewScheduleDefinitionId { get; set; }
        public string AccessReviewInstanceId { get; set; }
    }
    public partial class AccessreviewinstanceBatchrecorddecisionsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-batchrecorddecisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceBatchrecorddecisionsResponse> AccessreviewinstanceBatchrecorddecisionsAsync()
        {
            var p = new AccessreviewinstanceBatchrecorddecisionsParameter();
            return await this.SendAsync<AccessreviewinstanceBatchrecorddecisionsParameter, AccessreviewinstanceBatchrecorddecisionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-batchrecorddecisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceBatchrecorddecisionsResponse> AccessreviewinstanceBatchrecorddecisionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceBatchrecorddecisionsParameter();
            return await this.SendAsync<AccessreviewinstanceBatchrecorddecisionsParameter, AccessreviewinstanceBatchrecorddecisionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-batchrecorddecisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceBatchrecorddecisionsResponse> AccessreviewinstanceBatchrecorddecisionsAsync(AccessreviewinstanceBatchrecorddecisionsParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceBatchrecorddecisionsParameter, AccessreviewinstanceBatchrecorddecisionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewinstance-batchrecorddecisions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewinstanceBatchrecorddecisionsResponse> AccessreviewinstanceBatchrecorddecisionsAsync(AccessreviewinstanceBatchrecorddecisionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceBatchrecorddecisionsParameter, AccessreviewinstanceBatchrecorddecisionsResponse>(parameter, cancellationToken);
        }
    }
}
