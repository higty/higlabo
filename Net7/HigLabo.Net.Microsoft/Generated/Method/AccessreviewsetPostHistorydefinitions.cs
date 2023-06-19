using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-post-historydefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewsetPostHistorydefinitionsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_HistoryDefinitions: return $"/identityGovernance/accessReviews/historyDefinitions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum AccessReviewHistoryDefinitionAccessReviewHistoryStatus
        {
            Done,
            InProgress,
            Error,
            Requested,
            UnknownFutureValue,
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_HistoryDefinitions,
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
        public string? DisplayName { get; set; }
        public DateTimeOffset? ReviewHistoryPeriodStartDateTime { get; set; }
        public DateTimeOffset? ReviewHistoryPeriodEndDateTime { get; set; }
        public AccessReviewQueryScope[]? Scopes { get; set; }
        public AccessReviewHistoryScheduleSettings? ScheduleSettings { get; set; }
        public UserIdentity? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public String[]? Decisions { get; set; }
        public string? Id { get; set; }
        public AccessReviewHistoryDefinitionAccessReviewHistoryStatus Status { get; set; }
        public AccessReviewHistoryInstance[]? Instances { get; set; }
    }
    public partial class AccessreviewsetPostHistorydefinitionsResponse : RestApiResponse
    {
        public enum AccessReviewHistoryDefinitionAccessReviewHistoryStatus
        {
            Done,
            InProgress,
            Error,
            Requested,
            UnknownFutureValue,
        }

        public UserIdentity? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public String[]? Decisions { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ReviewHistoryPeriodEndDateTime { get; set; }
        public DateTimeOffset? ReviewHistoryPeriodStartDateTime { get; set; }
        public AccessReviewHistoryScheduleSettings? ScheduleSettings { get; set; }
        public AccessReviewScope[]? Scopes { get; set; }
        public AccessReviewHistoryDefinitionAccessReviewHistoryStatus Status { get; set; }
        public AccessReviewHistoryInstance[]? Instances { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-post-historydefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-post-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewsetPostHistorydefinitionsResponse> AccessreviewsetPostHistorydefinitionsAsync()
        {
            var p = new AccessreviewsetPostHistorydefinitionsParameter();
            return await this.SendAsync<AccessreviewsetPostHistorydefinitionsParameter, AccessreviewsetPostHistorydefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-post-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewsetPostHistorydefinitionsResponse> AccessreviewsetPostHistorydefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewsetPostHistorydefinitionsParameter();
            return await this.SendAsync<AccessreviewsetPostHistorydefinitionsParameter, AccessreviewsetPostHistorydefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-post-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewsetPostHistorydefinitionsResponse> AccessreviewsetPostHistorydefinitionsAsync(AccessreviewsetPostHistorydefinitionsParameter parameter)
        {
            return await this.SendAsync<AccessreviewsetPostHistorydefinitionsParameter, AccessreviewsetPostHistorydefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-post-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewsetPostHistorydefinitionsResponse> AccessreviewsetPostHistorydefinitionsAsync(AccessreviewsetPostHistorydefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewsetPostHistorydefinitionsParameter, AccessreviewsetPostHistorydefinitionsResponse>(parameter, cancellationToken);
        }
    }
}
