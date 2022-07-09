using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TimeoffrequestDeleteParameter : IRestApiParameter
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
                    case ApiPath.Teams_TeamId_Schedule_TimeOffRequests_TimeOffRequestId: return $"/teams/{TeamId}/schedule/timeOffRequests/{TimeOffRequestId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimeOffRequests_TimeOffRequestId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
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
