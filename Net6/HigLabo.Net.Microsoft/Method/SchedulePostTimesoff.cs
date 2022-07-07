using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SchedulePostTimesoffParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string TeamId { get; set; }
    }
    public partial class SchedulePostTimesoffResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public TimeOffItem? SharedTimeOff { get; set; }
        public TimeOffItem? DraftTimeOff { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-timesoff?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostTimesoffResponse> SchedulePostTimesoffAsync()
        {
            var p = new SchedulePostTimesoffParameter();
            return await this.SendAsync<SchedulePostTimesoffParameter, SchedulePostTimesoffResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-timesoff?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostTimesoffResponse> SchedulePostTimesoffAsync(CancellationToken cancellationToken)
        {
            var p = new SchedulePostTimesoffParameter();
            return await this.SendAsync<SchedulePostTimesoffParameter, SchedulePostTimesoffResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-timesoff?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostTimesoffResponse> SchedulePostTimesoffAsync(SchedulePostTimesoffParameter parameter)
        {
            return await this.SendAsync<SchedulePostTimesoffParameter, SchedulePostTimesoffResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-timesoff?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostTimesoffResponse> SchedulePostTimesoffAsync(SchedulePostTimesoffParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchedulePostTimesoffParameter, SchedulePostTimesoffResponse>(parameter, cancellationToken);
        }
    }
}
