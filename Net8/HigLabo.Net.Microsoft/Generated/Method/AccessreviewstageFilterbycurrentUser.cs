using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewstageFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages_FilterByCurrentUser: return $"/identityGovernance/accessReviews/definitions/{AccessReviewScheduleDefinitionId}/instances/{AccessReviewInstanceId}/stages/filterByCurrentUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            EndDateTime,
            FallbackReviewers,
            Id,
            Reviewers,
            StartDateTime,
            Status,
            Decisions,
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_Definitions_AccessReviewScheduleDefinitionId_Instances_AccessReviewInstanceId_Stages_FilterByCurrentUser,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class AccessreviewstageFilterbycurrentUserResponse : RestApiResponse
    {
        public AccessReviewStage[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewstageFilterbycurrentUserResponse> AccessreviewstageFilterbycurrentUserAsync()
        {
            var p = new AccessreviewstageFilterbycurrentUserParameter();
            return await this.SendAsync<AccessreviewstageFilterbycurrentUserParameter, AccessreviewstageFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewstageFilterbycurrentUserResponse> AccessreviewstageFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewstageFilterbycurrentUserParameter();
            return await this.SendAsync<AccessreviewstageFilterbycurrentUserParameter, AccessreviewstageFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewstageFilterbycurrentUserResponse> AccessreviewstageFilterbycurrentUserAsync(AccessreviewstageFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<AccessreviewstageFilterbycurrentUserParameter, AccessreviewstageFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewstage-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewstageFilterbycurrentUserResponse> AccessreviewstageFilterbycurrentUserAsync(AccessreviewstageFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewstageFilterbycurrentUserParameter, AccessreviewstageFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
