﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timeoffreasons?view=graph-rest-1.0
    /// </summary>
    public partial class SchedulePostTimeoffreasonsParameter : IRestApiParameter
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
    public partial class SchedulePostTimeoffreasonsResponse : RestApiResponse
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
        public async ValueTask<SchedulePostTimeoffreasonsResponse> SchedulePostTimeoffreasonsAsync()
        {
            var p = new SchedulePostTimeoffreasonsParameter();
            return await this.SendAsync<SchedulePostTimeoffreasonsParameter, SchedulePostTimeoffreasonsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulePostTimeoffreasonsResponse> SchedulePostTimeoffreasonsAsync(CancellationToken cancellationToken)
        {
            var p = new SchedulePostTimeoffreasonsParameter();
            return await this.SendAsync<SchedulePostTimeoffreasonsParameter, SchedulePostTimeoffreasonsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulePostTimeoffreasonsResponse> SchedulePostTimeoffreasonsAsync(SchedulePostTimeoffreasonsParameter parameter)
        {
            return await this.SendAsync<SchedulePostTimeoffreasonsParameter, SchedulePostTimeoffreasonsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulePostTimeoffreasonsResponse> SchedulePostTimeoffreasonsAsync(SchedulePostTimeoffreasonsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchedulePostTimeoffreasonsParameter, SchedulePostTimeoffreasonsResponse>(parameter, cancellationToken);
        }
    }
}
