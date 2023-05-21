using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timesoff?view=graph-rest-1.0
    /// </summary>
    public partial class SchedulePostTimesoffParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_TimesOff: return $"/teams/{TeamId}/schedule/timesOff";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimesOff,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DateTimeOffset? CreatedDateTime { get; set; }
        public TimeOffItem? DraftTimeOff { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public TimeOffItem? SharedTimeOff { get; set; }
        public string? UserId { get; set; }
    }
    public partial class SchedulePostTimesoffResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public TimeOffItem? DraftTimeOff { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public TimeOffItem? SharedTimeOff { get; set; }
        public string? UserId { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timesoff?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timesoff?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostTimesoffResponse> SchedulePostTimesoffAsync()
        {
            var p = new SchedulePostTimesoffParameter();
            return await this.SendAsync<SchedulePostTimesoffParameter, SchedulePostTimesoffResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timesoff?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostTimesoffResponse> SchedulePostTimesoffAsync(CancellationToken cancellationToken)
        {
            var p = new SchedulePostTimesoffParameter();
            return await this.SendAsync<SchedulePostTimesoffParameter, SchedulePostTimesoffResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timesoff?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostTimesoffResponse> SchedulePostTimesoffAsync(SchedulePostTimesoffParameter parameter)
        {
            return await this.SendAsync<SchedulePostTimesoffParameter, SchedulePostTimesoffResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timesoff?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostTimesoffResponse> SchedulePostTimesoffAsync(SchedulePostTimesoffParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchedulePostTimesoffParameter, SchedulePostTimesoffResponse>(parameter, cancellationToken);
        }
    }
}
