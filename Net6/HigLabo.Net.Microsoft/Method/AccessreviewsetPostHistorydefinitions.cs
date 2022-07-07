using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewsetPostHistorydefinitionsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_HistoryDefinitions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_HistoryDefinitions: return $"/identityGovernance/accessReviews/historyDefinitions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public DateTimeOffset? ReviewHistoryPeriodStartDateTime { get; set; }
        public DateTimeOffset? ReviewHistoryPeriodEndDateTime { get; set; }
        public AccessReviewQueryScope[]? Scopes { get; set; }
        public AccessReviewHistoryScheduleSettings? ScheduleSettings { get; set; }
    }
    public partial class AccessreviewsetPostHistorydefinitionsResponse : RestApiResponse
    {
        public enum AccessReviewHistoryDefinitionString
        {
            Approve,
            Deny,
            DontKnow,
            NotReviewed,
            NotNotified,
        }
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
        public AccessReviewHistoryDefinitionString Decisions { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ReviewHistoryPeriodEndDateTime { get; set; }
        public DateTimeOffset? ReviewHistoryPeriodStartDateTime { get; set; }
        public AccessReviewHistoryScheduleSettings? ScheduleSettings { get; set; }
        public AccessReviewScope[]? Scopes { get; set; }
        public AccessReviewHistoryDefinitionAccessReviewHistoryStatus Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewset-post-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetPostHistorydefinitionsResponse> AccessreviewsetPostHistorydefinitionsAsync()
        {
            var p = new AccessreviewsetPostHistorydefinitionsParameter();
            return await this.SendAsync<AccessreviewsetPostHistorydefinitionsParameter, AccessreviewsetPostHistorydefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewset-post-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetPostHistorydefinitionsResponse> AccessreviewsetPostHistorydefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewsetPostHistorydefinitionsParameter();
            return await this.SendAsync<AccessreviewsetPostHistorydefinitionsParameter, AccessreviewsetPostHistorydefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewset-post-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetPostHistorydefinitionsResponse> AccessreviewsetPostHistorydefinitionsAsync(AccessreviewsetPostHistorydefinitionsParameter parameter)
        {
            return await this.SendAsync<AccessreviewsetPostHistorydefinitionsParameter, AccessreviewsetPostHistorydefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewset-post-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetPostHistorydefinitionsResponse> AccessreviewsetPostHistorydefinitionsAsync(AccessreviewsetPostHistorydefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewsetPostHistorydefinitionsParameter, AccessreviewsetPostHistorydefinitionsResponse>(parameter, cancellationToken);
        }
    }
}
