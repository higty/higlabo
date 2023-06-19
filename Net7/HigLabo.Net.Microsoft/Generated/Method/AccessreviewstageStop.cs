using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-stop?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewstageStopParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessReviewScheduleDefinitionId { get; set; }
            public string? AccessReviewInstanceId { get; set; }
            public string? AccessReviewStageId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages_AccessReviewStageId_Stop: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/stages/{AccessReviewStageId}/stop";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages_AccessReviewStageId_Stop,
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
    public partial class AccessreviewstageStopResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-stop?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-stop?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewstageStopResponse> AccessreviewstageStopAsync()
        {
            var p = new AccessreviewstageStopParameter();
            return await this.SendAsync<AccessreviewstageStopParameter, AccessreviewstageStopResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-stop?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewstageStopResponse> AccessreviewstageStopAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewstageStopParameter();
            return await this.SendAsync<AccessreviewstageStopParameter, AccessreviewstageStopResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-stop?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewstageStopResponse> AccessreviewstageStopAsync(AccessreviewstageStopParameter parameter)
        {
            return await this.SendAsync<AccessreviewstageStopParameter, AccessreviewstageStopResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-stop?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewstageStopResponse> AccessreviewstageStopAsync(AccessreviewstageStopParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewstageStopParameter, AccessreviewstageStopResponse>(parameter, cancellationToken);
        }
    }
}
