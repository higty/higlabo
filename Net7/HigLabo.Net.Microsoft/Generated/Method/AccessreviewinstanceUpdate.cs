using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-update?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewinstanceUpdateParameter : IRestApiParameter
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
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId,
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
        public AccessReviewReviewerScope[]? FallbackReviewers { get; set; }
        public AccessReviewReviewerScope[]? Reviewers { get; set; }
        public AccessReviewScope? Scope { get; set; }
    }
    public partial class AccessreviewinstanceUpdateResponse : RestApiResponse
    {
        public DateTimeOffset? EndDateTime { get; set; }
        public AccessReviewReviewerScope[]? FallbackReviewers { get; set; }
        public string? Id { get; set; }
        public AccessReviewReviewerScope[]? Reviewers { get; set; }
        public AccessReviewScope? Scope { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? Status { get; set; }
        public AccessReviewReviewer[]? ContactedReviewers { get; set; }
        public AccessReviewInstanceDecisionItem[]? Decisions { get; set; }
        public AccessReviewStage[]? Stages { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewinstanceUpdateResponse> AccessreviewinstanceUpdateAsync()
        {
            var p = new AccessreviewinstanceUpdateParameter();
            return await this.SendAsync<AccessreviewinstanceUpdateParameter, AccessreviewinstanceUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewinstanceUpdateResponse> AccessreviewinstanceUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewinstanceUpdateParameter();
            return await this.SendAsync<AccessreviewinstanceUpdateParameter, AccessreviewinstanceUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewinstanceUpdateResponse> AccessreviewinstanceUpdateAsync(AccessreviewinstanceUpdateParameter parameter)
        {
            return await this.SendAsync<AccessreviewinstanceUpdateParameter, AccessreviewinstanceUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewinstance-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewinstanceUpdateResponse> AccessreviewinstanceUpdateAsync(AccessreviewinstanceUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewinstanceUpdateParameter, AccessreviewinstanceUpdateResponse>(parameter, cancellationToken);
        }
    }
}
