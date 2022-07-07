using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TimeoffrequestDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimeOffRequests_TimeOffRequestId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_TimeOffRequests_TimeOffRequestId: return $"/teams/{TeamId}/schedule/timeOffRequests/{TimeOffRequestId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string TeamId { get; set; }
        public string TimeOffRequestId { get; set; }
    }
    public partial class TimeoffrequestDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffrequestDeleteResponse> TimeoffrequestDeleteAsync()
        {
            var p = new TimeoffrequestDeleteParameter();
            return await this.SendAsync<TimeoffrequestDeleteParameter, TimeoffrequestDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffrequestDeleteResponse> TimeoffrequestDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TimeoffrequestDeleteParameter();
            return await this.SendAsync<TimeoffrequestDeleteParameter, TimeoffrequestDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffrequestDeleteResponse> TimeoffrequestDeleteAsync(TimeoffrequestDeleteParameter parameter)
        {
            return await this.SendAsync<TimeoffrequestDeleteParameter, TimeoffrequestDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffrequestDeleteResponse> TimeoffrequestDeleteAsync(TimeoffrequestDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TimeoffrequestDeleteParameter, TimeoffrequestDeleteResponse>(parameter, cancellationToken);
        }
    }
}
