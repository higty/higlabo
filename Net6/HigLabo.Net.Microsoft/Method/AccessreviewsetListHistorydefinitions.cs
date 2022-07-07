using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccessreviewsetListHistorydefinitionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class AccessreviewsetListHistorydefinitionsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/accessreviewhistorydefinition?view=graph-rest-1.0
        /// </summary>
        public partial class AccessReviewHistoryDefinition
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

        public AccessReviewHistoryDefinition[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetListHistorydefinitionsResponse> AccessreviewsetListHistorydefinitionsAsync()
        {
            var p = new AccessreviewsetListHistorydefinitionsParameter();
            return await this.SendAsync<AccessreviewsetListHistorydefinitionsParameter, AccessreviewsetListHistorydefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetListHistorydefinitionsResponse> AccessreviewsetListHistorydefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewsetListHistorydefinitionsParameter();
            return await this.SendAsync<AccessreviewsetListHistorydefinitionsParameter, AccessreviewsetListHistorydefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetListHistorydefinitionsResponse> AccessreviewsetListHistorydefinitionsAsync(AccessreviewsetListHistorydefinitionsParameter parameter)
        {
            return await this.SendAsync<AccessreviewsetListHistorydefinitionsParameter, AccessreviewsetListHistorydefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<AccessreviewsetListHistorydefinitionsResponse> AccessreviewsetListHistorydefinitionsAsync(AccessreviewsetListHistorydefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewsetListHistorydefinitionsParameter, AccessreviewsetListHistorydefinitionsResponse>(parameter, cancellationToken);
        }
    }
}
