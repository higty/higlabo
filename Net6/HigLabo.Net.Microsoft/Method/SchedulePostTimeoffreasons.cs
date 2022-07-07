using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SchedulePostTimeoffreasonsParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string TeamId { get; set; }
    }
    public partial class SchedulePostTimeoffreasonsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public TimeOffReasonIconType? IconType { get; set; }
        public bool? IsActive { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostTimeoffreasonsResponse> SchedulePostTimeoffreasonsAsync()
        {
            var p = new SchedulePostTimeoffreasonsParameter();
            return await this.SendAsync<SchedulePostTimeoffreasonsParameter, SchedulePostTimeoffreasonsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostTimeoffreasonsResponse> SchedulePostTimeoffreasonsAsync(CancellationToken cancellationToken)
        {
            var p = new SchedulePostTimeoffreasonsParameter();
            return await this.SendAsync<SchedulePostTimeoffreasonsParameter, SchedulePostTimeoffreasonsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostTimeoffreasonsResponse> SchedulePostTimeoffreasonsAsync(SchedulePostTimeoffreasonsParameter parameter)
        {
            return await this.SendAsync<SchedulePostTimeoffreasonsParameter, SchedulePostTimeoffreasonsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostTimeoffreasonsResponse> SchedulePostTimeoffreasonsAsync(SchedulePostTimeoffreasonsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchedulePostTimeoffreasonsParameter, SchedulePostTimeoffreasonsResponse>(parameter, cancellationToken);
        }
    }
}
