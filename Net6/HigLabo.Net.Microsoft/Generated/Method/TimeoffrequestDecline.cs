using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
    /// </summary>
    public partial class TimeoffrequestDeclineParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? TimeOffRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_TimeOffRequests_TimeOffRequestId_Decline: return $"/teams/{TeamId}/schedule/timeOffRequests/{TimeOffRequestId}/decline";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimeOffRequests_TimeOffRequestId_Decline,
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
        public string? Message { get; set; }
    }
    public partial class TimeoffrequestDeclineResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffrequestDeclineResponse> TimeoffrequestDeclineAsync()
        {
            var p = new TimeoffrequestDeclineParameter();
            return await this.SendAsync<TimeoffrequestDeclineParameter, TimeoffrequestDeclineResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffrequestDeclineResponse> TimeoffrequestDeclineAsync(CancellationToken cancellationToken)
        {
            var p = new TimeoffrequestDeclineParameter();
            return await this.SendAsync<TimeoffrequestDeclineParameter, TimeoffrequestDeclineResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffrequestDeclineResponse> TimeoffrequestDeclineAsync(TimeoffrequestDeclineParameter parameter)
        {
            return await this.SendAsync<TimeoffrequestDeclineParameter, TimeoffrequestDeclineResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffrequestDeclineResponse> TimeoffrequestDeclineAsync(TimeoffrequestDeclineParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TimeoffrequestDeclineParameter, TimeoffrequestDeclineResponse>(parameter, cancellationToken);
        }
    }
}
