using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-update?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewScheduleDefinitionUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ReviewId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_ReviewId: return $"/identityGovernance/accessReviews/definitions/{ReviewId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_ReviewId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string? DescriptionForAdmins { get; set; }
        public string? DescriptionForReviewers { get; set; }
        public string? DisplayName { get; set; }
        public AccessReviewReviewerScope[]? FallbackReviewers { get; set; }
        public AccessReviewReviewerScope[]? Reviewers { get; set; }
        public AccessReviewStageSettings[]? StageSettings { get; set; }
        public AccessReviewScheduleSettings? Settings { get; set; }
    }
    public partial class AccessReviewScheduleDefinitionUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewScheduleDefinitionUpdateResponse> AccessReviewScheduleDefinitionUpdateAsync()
        {
            var p = new AccessReviewScheduleDefinitionUpdateParameter();
            return await this.SendAsync<AccessReviewScheduleDefinitionUpdateParameter, AccessReviewScheduleDefinitionUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewScheduleDefinitionUpdateResponse> AccessReviewScheduleDefinitionUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AccessReviewScheduleDefinitionUpdateParameter();
            return await this.SendAsync<AccessReviewScheduleDefinitionUpdateParameter, AccessReviewScheduleDefinitionUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewScheduleDefinitionUpdateResponse> AccessReviewScheduleDefinitionUpdateAsync(AccessReviewScheduleDefinitionUpdateParameter parameter)
        {
            return await this.SendAsync<AccessReviewScheduleDefinitionUpdateParameter, AccessReviewScheduleDefinitionUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessReviewScheduleDefinitionUpdateResponse> AccessReviewScheduleDefinitionUpdateAsync(AccessReviewScheduleDefinitionUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessReviewScheduleDefinitionUpdateParameter, AccessReviewScheduleDefinitionUpdateResponse>(parameter, cancellationToken);
        }
    }
}
