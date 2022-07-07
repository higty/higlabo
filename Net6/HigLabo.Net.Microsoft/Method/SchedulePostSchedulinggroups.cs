using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SchedulePostSchedulinggroupsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Schedule_SchedulingGroups,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_SchedulingGroups: return $"/teams/{TeamId}/schedule/schedulingGroups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string TeamId { get; set; }
    }
    public partial class SchedulePostSchedulinggroupsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsActive { get; set; }
        public string[]? UserIds { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-schedulinggroups?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostSchedulinggroupsResponse> SchedulePostSchedulinggroupsAsync()
        {
            var p = new SchedulePostSchedulinggroupsParameter();
            return await this.SendAsync<SchedulePostSchedulinggroupsParameter, SchedulePostSchedulinggroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-schedulinggroups?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostSchedulinggroupsResponse> SchedulePostSchedulinggroupsAsync(CancellationToken cancellationToken)
        {
            var p = new SchedulePostSchedulinggroupsParameter();
            return await this.SendAsync<SchedulePostSchedulinggroupsParameter, SchedulePostSchedulinggroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-schedulinggroups?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostSchedulinggroupsResponse> SchedulePostSchedulinggroupsAsync(SchedulePostSchedulinggroupsParameter parameter)
        {
            return await this.SendAsync<SchedulePostSchedulinggroupsParameter, SchedulePostSchedulinggroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-post-schedulinggroups?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulePostSchedulinggroupsResponse> SchedulePostSchedulinggroupsAsync(SchedulePostSchedulinggroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchedulePostSchedulinggroupsParameter, SchedulePostSchedulinggroupsResponse>(parameter, cancellationToken);
        }
    }
}
