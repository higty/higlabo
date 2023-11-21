using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-list?view=graph-rest-1.0
    /// </summary>
    public partial class TimeoffrequestListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_TimeOffRequests: return $"/teams/{TeamId}/schedule/timeOffRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimeOffRequests,
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
    public partial class TimeoffrequestListResponse : RestApiResponse
    {
        public DateTimeOffset? EndDateTime { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? TimeOffReasonId { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffrequestListResponse> TimeoffrequestListAsync()
        {
            var p = new TimeoffrequestListParameter();
            return await this.SendAsync<TimeoffrequestListParameter, TimeoffrequestListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffrequestListResponse> TimeoffrequestListAsync(CancellationToken cancellationToken)
        {
            var p = new TimeoffrequestListParameter();
            return await this.SendAsync<TimeoffrequestListParameter, TimeoffrequestListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffrequestListResponse> TimeoffrequestListAsync(TimeoffrequestListParameter parameter)
        {
            return await this.SendAsync<TimeoffrequestListParameter, TimeoffrequestListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffrequestListResponse> TimeoffrequestListAsync(TimeoffrequestListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TimeoffrequestListParameter, TimeoffrequestListResponse>(parameter, cancellationToken);
        }
    }
}
