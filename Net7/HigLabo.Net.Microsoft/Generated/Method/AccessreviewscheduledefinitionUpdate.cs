using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-update?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewscheduledefinitionUpdateParameter : IRestApiParameter
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
    public partial class AccessreviewscheduledefinitionUpdateResponse : RestApiResponse
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
        public async Task<AccessreviewscheduledefinitionUpdateResponse> AccessreviewscheduledefinitionUpdateAsync()
        {
            var p = new AccessreviewscheduledefinitionUpdateParameter();
            return await this.SendAsync<AccessreviewscheduledefinitionUpdateParameter, AccessreviewscheduledefinitionUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionUpdateResponse> AccessreviewscheduledefinitionUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewscheduledefinitionUpdateParameter();
            return await this.SendAsync<AccessreviewscheduledefinitionUpdateParameter, AccessreviewscheduledefinitionUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionUpdateResponse> AccessreviewscheduledefinitionUpdateAsync(AccessreviewscheduledefinitionUpdateParameter parameter)
        {
            return await this.SendAsync<AccessreviewscheduledefinitionUpdateParameter, AccessreviewscheduledefinitionUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewscheduledefinition-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewscheduledefinitionUpdateResponse> AccessreviewscheduledefinitionUpdateAsync(AccessreviewscheduledefinitionUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewscheduledefinitionUpdateParameter, AccessreviewscheduledefinitionUpdateResponse>(parameter, cancellationToken);
        }
    }
}
