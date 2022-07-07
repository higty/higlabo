using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ScheduleListTimeoffreasonsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimeOffReasons,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_TimeOffReasons: return $"/teams/{TeamId}/schedule/timeOffReasons";
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
    public partial class ScheduleListTimeoffreasonsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/timeoffreason?view=graph-rest-1.0
        /// </summary>
        public partial class TimeOffReason
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public TimeOffReasonIconType? IconType { get; set; }
            public bool? IsActive { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public IdentitySet? LastModifiedBy { get; set; }
        }

        public TimeOffReason[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListTimeoffreasonsResponse> ScheduleListTimeoffreasonsAsync()
        {
            var p = new ScheduleListTimeoffreasonsParameter();
            return await this.SendAsync<ScheduleListTimeoffreasonsParameter, ScheduleListTimeoffreasonsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListTimeoffreasonsResponse> ScheduleListTimeoffreasonsAsync(CancellationToken cancellationToken)
        {
            var p = new ScheduleListTimeoffreasonsParameter();
            return await this.SendAsync<ScheduleListTimeoffreasonsParameter, ScheduleListTimeoffreasonsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListTimeoffreasonsResponse> ScheduleListTimeoffreasonsAsync(ScheduleListTimeoffreasonsParameter parameter)
        {
            return await this.SendAsync<ScheduleListTimeoffreasonsParameter, ScheduleListTimeoffreasonsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListTimeoffreasonsResponse> ScheduleListTimeoffreasonsAsync(ScheduleListTimeoffreasonsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ScheduleListTimeoffreasonsParameter, ScheduleListTimeoffreasonsResponse>(parameter, cancellationToken);
        }
    }
}
