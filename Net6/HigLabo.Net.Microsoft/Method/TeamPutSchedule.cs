using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamPutScheduleParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Schedule,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule: return $"/teams/{TeamId}/schedule";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string TeamId { get; set; }
    }
    public partial class TeamPutScheduleResponse : RestApiResponse
    {
        public enum ScheduleOperationStatus
        {
            NotStarted,
            Running,
            Completed,
            Failed,
        }

        public string? Id { get; set; }
        public bool? Enabled { get; set; }
        public string? TimeZone { get; set; }
        public ScheduleOperationStatus ProvisionStatus { get; set; }
        public string? ProvisionStatusCode { get; set; }
        public bool? TimeClockEnabled { get; set; }
        public bool? OpenShiftsEnabled { get; set; }
        public bool? SwapShiftsRequestsEnabled { get; set; }
        public bool? OfferShiftRequestsEnabled { get; set; }
        public bool? TimeOffRequestsEnabled { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-put-schedule?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPutScheduleResponse> TeamPutScheduleAsync()
        {
            var p = new TeamPutScheduleParameter();
            return await this.SendAsync<TeamPutScheduleParameter, TeamPutScheduleResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-put-schedule?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPutScheduleResponse> TeamPutScheduleAsync(CancellationToken cancellationToken)
        {
            var p = new TeamPutScheduleParameter();
            return await this.SendAsync<TeamPutScheduleParameter, TeamPutScheduleResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-put-schedule?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPutScheduleResponse> TeamPutScheduleAsync(TeamPutScheduleParameter parameter)
        {
            return await this.SendAsync<TeamPutScheduleParameter, TeamPutScheduleResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-put-schedule?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPutScheduleResponse> TeamPutScheduleAsync(TeamPutScheduleParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamPutScheduleParameter, TeamPutScheduleResponse>(parameter, cancellationToken);
        }
    }
}
