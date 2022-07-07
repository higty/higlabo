using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ScheduleListTimesoffParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimesOff,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_TimesOff: return $"/teams/{TeamId}/schedule/timesOff";
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
        public string TeamId { get; set; }
    }
    public partial class ScheduleListTimesoffResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/timeoff?view=graph-rest-1.0
        /// </summary>
        public partial class TimeOff
        {
            public string? Id { get; set; }
            public string? UserId { get; set; }
            public TimeOffItem? SharedTimeOff { get; set; }
            public TimeOffItem? DraftTimeOff { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public IdentitySet? LastModifiedBy { get; set; }
        }

        public TimeOff[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-timesoff?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListTimesoffResponse> ScheduleListTimesoffAsync()
        {
            var p = new ScheduleListTimesoffParameter();
            return await this.SendAsync<ScheduleListTimesoffParameter, ScheduleListTimesoffResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-timesoff?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListTimesoffResponse> ScheduleListTimesoffAsync(CancellationToken cancellationToken)
        {
            var p = new ScheduleListTimesoffParameter();
            return await this.SendAsync<ScheduleListTimesoffParameter, ScheduleListTimesoffResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-timesoff?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListTimesoffResponse> ScheduleListTimesoffAsync(ScheduleListTimesoffParameter parameter)
        {
            return await this.SendAsync<ScheduleListTimesoffParameter, ScheduleListTimesoffResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-timesoff?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListTimesoffResponse> ScheduleListTimesoffAsync(ScheduleListTimesoffParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ScheduleListTimesoffParameter, ScheduleListTimesoffResponse>(parameter, cancellationToken);
        }
    }
}
