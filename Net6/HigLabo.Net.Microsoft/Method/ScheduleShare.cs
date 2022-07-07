using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ScheduleShareParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Schedule_Share,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_Share: return $"/teams/{TeamId}/schedule/share";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public bool? NotifyTeam { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string TeamId { get; set; }
    }
    public partial class ScheduleShareResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-share?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleShareResponse> ScheduleShareAsync()
        {
            var p = new ScheduleShareParameter();
            return await this.SendAsync<ScheduleShareParameter, ScheduleShareResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-share?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleShareResponse> ScheduleShareAsync(CancellationToken cancellationToken)
        {
            var p = new ScheduleShareParameter();
            return await this.SendAsync<ScheduleShareParameter, ScheduleShareResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-share?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleShareResponse> ScheduleShareAsync(ScheduleShareParameter parameter)
        {
            return await this.SendAsync<ScheduleShareParameter, ScheduleShareResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-share?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleShareResponse> ScheduleShareAsync(ScheduleShareParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ScheduleShareParameter, ScheduleShareResponse>(parameter, cancellationToken);
        }
    }
}
