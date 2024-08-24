using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-delete?view=graph-rest-1.0
    /// </summary>
    public partial class TimeoffRequestDeleteParameter : IRestApiParameter
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
    public partial class TimeoffRequestDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffRequestDeleteResponse> TimeoffRequestDeleteAsync()
        {
            var p = new TimeoffRequestDeleteParameter();
            return await this.SendAsync<TimeoffRequestDeleteParameter, TimeoffRequestDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffRequestDeleteResponse> TimeoffRequestDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TimeoffRequestDeleteParameter();
            return await this.SendAsync<TimeoffRequestDeleteParameter, TimeoffRequestDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffRequestDeleteResponse> TimeoffRequestDeleteAsync(TimeoffRequestDeleteParameter parameter)
        {
            return await this.SendAsync<TimeoffRequestDeleteParameter, TimeoffRequestDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffRequestDeleteResponse> TimeoffRequestDeleteAsync(TimeoffRequestDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TimeoffRequestDeleteParameter, TimeoffRequestDeleteResponse>(parameter, cancellationToken);
        }
    }
}
