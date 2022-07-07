using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TimeoffrequestDeclineParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimeOffRequests_TimeOffRequestId_Decline,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_TimeOffRequests_TimeOffRequestId_Decline: return $"/teams/{TeamId}/schedule/timeOffRequests/{TimeOffRequestId}/decline";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Message { get; set; }
        public string TeamId { get; set; }
        public string TimeOffRequestId { get; set; }
    }
    public partial class TimeoffrequestDeclineResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffrequestDeclineResponse> TimeoffrequestDeclineAsync()
        {
            var p = new TimeoffrequestDeclineParameter();
            return await this.SendAsync<TimeoffrequestDeclineParameter, TimeoffrequestDeclineResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffrequestDeclineResponse> TimeoffrequestDeclineAsync(CancellationToken cancellationToken)
        {
            var p = new TimeoffrequestDeclineParameter();
            return await this.SendAsync<TimeoffrequestDeclineParameter, TimeoffrequestDeclineResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffrequestDeclineResponse> TimeoffrequestDeclineAsync(TimeoffrequestDeclineParameter parameter)
        {
            return await this.SendAsync<TimeoffrequestDeclineParameter, TimeoffrequestDeclineResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffrequestDeclineResponse> TimeoffrequestDeclineAsync(TimeoffrequestDeclineParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TimeoffrequestDeclineParameter, TimeoffrequestDeclineResponse>(parameter, cancellationToken);
        }
    }
}
