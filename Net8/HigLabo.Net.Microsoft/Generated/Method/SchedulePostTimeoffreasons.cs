using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timeoffreasons?view=graph-rest-1.0
    /// </summary>
    public partial class SchedulePostTimeoffReasonsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_TimeOffReasons: return $"/teams/{TeamId}/schedule/timeOffReasons";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimeOffReasons,
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
        public string? DisplayName { get; set; }
        public TimeOffReasonIconType? IconType { get; set; }
        public string? Id { get; set; }
        public bool? IsActive { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
    }
    public partial class SchedulePostTimeoffReasonsResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public TimeOffReasonIconType? IconType { get; set; }
        public string? Id { get; set; }
        public bool? IsActive { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timeoffreasons?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulePostTimeoffReasonsResponse> SchedulePostTimeoffReasonsAsync()
        {
            var p = new SchedulePostTimeoffReasonsParameter();
            return await this.SendAsync<SchedulePostTimeoffReasonsParameter, SchedulePostTimeoffReasonsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulePostTimeoffReasonsResponse> SchedulePostTimeoffReasonsAsync(CancellationToken cancellationToken)
        {
            var p = new SchedulePostTimeoffReasonsParameter();
            return await this.SendAsync<SchedulePostTimeoffReasonsParameter, SchedulePostTimeoffReasonsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulePostTimeoffReasonsResponse> SchedulePostTimeoffReasonsAsync(SchedulePostTimeoffReasonsParameter parameter)
        {
            return await this.SendAsync<SchedulePostTimeoffReasonsParameter, SchedulePostTimeoffReasonsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulePostTimeoffReasonsResponse> SchedulePostTimeoffReasonsAsync(SchedulePostTimeoffReasonsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchedulePostTimeoffReasonsParameter, SchedulePostTimeoffReasonsResponse>(parameter, cancellationToken);
        }
    }
}
