using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SchedulePostShiftsParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string TeamId { get; set; }
    }
    public partial class SchedulePostShiftsResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-shifts?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostShiftsResponse> SchedulePostShiftsAsync()
        {
            var p = new SchedulePostShiftsParameter();
            return await this.SendAsync<SchedulePostShiftsParameter, SchedulePostShiftsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-shifts?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostShiftsResponse> SchedulePostShiftsAsync(CancellationToken cancellationToken)
        {
            var p = new SchedulePostShiftsParameter();
            return await this.SendAsync<SchedulePostShiftsParameter, SchedulePostShiftsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-shifts?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostShiftsResponse> SchedulePostShiftsAsync(SchedulePostShiftsParameter parameter)
        {
            return await this.SendAsync<SchedulePostShiftsParameter, SchedulePostShiftsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-shifts?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostShiftsResponse> SchedulePostShiftsAsync(SchedulePostShiftsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchedulePostShiftsParameter, SchedulePostShiftsResponse>(parameter, cancellationToken);
        }
    }
}
