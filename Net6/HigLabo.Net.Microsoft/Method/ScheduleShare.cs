using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ScheduleShareParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_Share: return $"/teams/{TeamId}/schedule/share";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Schedule_Share,
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
        public bool? NotifyTeam { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
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
