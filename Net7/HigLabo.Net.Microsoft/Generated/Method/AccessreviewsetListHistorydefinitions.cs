using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class AccessreviewsetListHistorydefinitionsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            CreatedBy,
            CreatedDateTime,
            Decisions,
            DisplayName,
            Id,
            ReviewHistoryPeriodEndDateTime,
            ReviewHistoryPeriodStartDateTime,
            ScheduleSettings,
            Scopes,
            Status,
            Instances,
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
        public AccessReviewHistoryDefinition[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewsetListHistorydefinitionsResponse> AccessreviewsetListHistorydefinitionsAsync()
        {
            var p = new AccessreviewsetListHistorydefinitionsParameter();
            return await this.SendAsync<AccessreviewsetListHistorydefinitionsParameter, AccessreviewsetListHistorydefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewsetListHistorydefinitionsResponse> AccessreviewsetListHistorydefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new AccessreviewsetListHistorydefinitionsParameter();
            return await this.SendAsync<AccessreviewsetListHistorydefinitionsParameter, AccessreviewsetListHistorydefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewsetListHistorydefinitionsResponse> AccessreviewsetListHistorydefinitionsAsync(AccessreviewsetListHistorydefinitionsParameter parameter)
        {
            return await this.SendAsync<AccessreviewsetListHistorydefinitionsParameter, AccessreviewsetListHistorydefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accessreviewset-list-historydefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessreviewsetListHistorydefinitionsResponse> AccessreviewsetListHistorydefinitionsAsync(AccessreviewsetListHistorydefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessreviewsetListHistorydefinitionsParameter, AccessreviewsetListHistorydefinitionsResponse>(parameter, cancellationToken);
        }
    }
}
