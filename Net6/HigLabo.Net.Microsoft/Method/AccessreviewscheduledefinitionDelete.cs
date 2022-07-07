using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewscheduledefinitionDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string AccessReviewScheduleDefinitionId { get; set; }
    }
    public partial class AccessreviewscheduledefinitionDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionDeleteResponse> AccessreviewscheduledefinitionDeleteAsync()
        {
            var p = new AccessreviewscheduledefinitionDeleteParameter();
            return await this.SendAsync<AccessreviewscheduledefinitionDeleteParameter, AccessreviewscheduledefinitionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionDeleteResponse> AccessreviewscheduledefinitionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewscheduledefinitionDeleteParameter();
            return await this.SendAsync<AccessreviewscheduledefinitionDeleteParameter, AccessreviewscheduledefinitionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionDeleteResponse> AccessreviewscheduledefinitionDeleteAsync(AccessreviewscheduledefinitionDeleteParameter parameter)
        {
            return await this.SendAsync<AccessreviewscheduledefinitionDeleteParameter, AccessreviewscheduledefinitionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionDeleteResponse> AccessreviewscheduledefinitionDeleteAsync(AccessreviewscheduledefinitionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewscheduledefinitionDeleteParameter, AccessreviewscheduledefinitionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
