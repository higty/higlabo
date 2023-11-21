using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-get?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewhistorydefinitionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DefinitionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_AccessReviews_HistoryDefinitions_DefinitionId: return $"/identityGovernance/accessReviews/historyDefinitions/{DefinitionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_AccessReviews_HistoryDefinitions_DefinitionId,
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
    public partial class AccessreviewhistorydefinitionGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewhistorydefinitionGetResponse> AccessreviewhistorydefinitionGetAsync()
        {
            var p = new AccessreviewhistorydefinitionGetParameter();
            return await this.SendAsync<AccessreviewhistorydefinitionGetParameter, AccessreviewhistorydefinitionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewhistorydefinitionGetResponse> AccessreviewhistorydefinitionGetAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewhistorydefinitionGetParameter();
            return await this.SendAsync<AccessreviewhistorydefinitionGetParameter, AccessreviewhistorydefinitionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewhistorydefinitionGetResponse> AccessreviewhistorydefinitionGetAsync(AccessreviewhistorydefinitionGetParameter parameter)
        {
            return await this.SendAsync<AccessreviewhistorydefinitionGetParameter, AccessreviewhistorydefinitionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewhistorydefinition-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewhistorydefinitionGetResponse> AccessreviewhistorydefinitionGetAsync(AccessreviewhistorydefinitionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewhistorydefinitionGetParameter, AccessreviewhistorydefinitionGetResponse>(parameter, cancellationToken);
        }
    }
}
