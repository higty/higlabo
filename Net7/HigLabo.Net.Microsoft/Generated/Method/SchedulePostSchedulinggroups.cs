using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-post-schedulinggroups?view=graph-rest-1.0
    /// </summary>
    public partial class SchedulePostSchedulingGroupsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_SchedulingGroups: return $"/teams/{TeamId}/schedule/schedulingGroups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Schedule_SchedulingGroups,
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
        public string? Id { get; set; }
        public bool? IsActive { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string[]? UserIds { get; set; }
    }
    public partial class SchedulePostSchedulingGroupsResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsActive { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string[]? UserIds { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-post-schedulinggroups?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-schedulinggroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulePostSchedulingGroupsResponse> SchedulePostSchedulingGroupsAsync()
        {
            var p = new SchedulePostSchedulingGroupsParameter();
            return await this.SendAsync<SchedulePostSchedulingGroupsParameter, SchedulePostSchedulingGroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-schedulinggroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulePostSchedulingGroupsResponse> SchedulePostSchedulingGroupsAsync(CancellationToken cancellationToken)
        {
            var p = new SchedulePostSchedulingGroupsParameter();
            return await this.SendAsync<SchedulePostSchedulingGroupsParameter, SchedulePostSchedulingGroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-schedulinggroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulePostSchedulingGroupsResponse> SchedulePostSchedulingGroupsAsync(SchedulePostSchedulingGroupsParameter parameter)
        {
            return await this.SendAsync<SchedulePostSchedulingGroupsParameter, SchedulePostSchedulingGroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-post-schedulinggroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulePostSchedulingGroupsResponse> SchedulePostSchedulingGroupsAsync(SchedulePostSchedulingGroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchedulePostSchedulingGroupsParameter, SchedulePostSchedulingGroupsResponse>(parameter, cancellationToken);
        }
    }
}
