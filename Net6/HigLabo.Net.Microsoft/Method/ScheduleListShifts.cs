using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ScheduleListShiftsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_Shifts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_Shifts: return $"/teams/{TeamId}/schedule/shifts";
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
    public partial class ScheduleListShiftsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/shift?view=graph-rest-1.0
        /// </summary>
        public partial class Shift
        {
            public string? Id { get; set; }
            public string? UserId { get; set; }
            public string? SchedulingGroupId { get; set; }
            public ShiftItem? SharedShift { get; set; }
            public ShiftItem? DraftShift { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public IdentitySet? LastModifiedBy { get; set; }
        }

        public Shift[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListShiftsResponse> ScheduleListShiftsAsync()
        {
            var p = new ScheduleListShiftsParameter();
            return await this.SendAsync<ScheduleListShiftsParameter, ScheduleListShiftsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListShiftsResponse> ScheduleListShiftsAsync(CancellationToken cancellationToken)
        {
            var p = new ScheduleListShiftsParameter();
            return await this.SendAsync<ScheduleListShiftsParameter, ScheduleListShiftsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListShiftsResponse> ScheduleListShiftsAsync(ScheduleListShiftsParameter parameter)
        {
            return await this.SendAsync<ScheduleListShiftsParameter, ScheduleListShiftsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListShiftsResponse> ScheduleListShiftsAsync(ScheduleListShiftsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ScheduleListShiftsParameter, ScheduleListShiftsResponse>(parameter, cancellationToken);
        }
    }
}
