using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-delete?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewScheduleDefinitionDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessReviewScheduleDefinitionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class AccessReviewScheduleDefinitionDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewScheduleDefinitionDeleteResponse> AccessReviewScheduleDefinitionDeleteAsync()
        {
            var p = new AccessReviewScheduleDefinitionDeleteParameter();
            return await this.SendAsync<AccessReviewScheduleDefinitionDeleteParameter, AccessReviewScheduleDefinitionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewScheduleDefinitionDeleteResponse> AccessReviewScheduleDefinitionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AccessReviewScheduleDefinitionDeleteParameter();
            return await this.SendAsync<AccessReviewScheduleDefinitionDeleteParameter, AccessReviewScheduleDefinitionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewScheduleDefinitionDeleteResponse> AccessReviewScheduleDefinitionDeleteAsync(AccessReviewScheduleDefinitionDeleteParameter parameter)
        {
            return await this.SendAsync<AccessReviewScheduleDefinitionDeleteParameter, AccessReviewScheduleDefinitionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewScheduleDefinitionDeleteResponse> AccessReviewScheduleDefinitionDeleteAsync(AccessReviewScheduleDefinitionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessReviewScheduleDefinitionDeleteParameter, AccessReviewScheduleDefinitionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
