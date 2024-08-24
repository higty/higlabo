using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-approve?view=graph-rest-1.0
    /// </summary>
    public partial class TimeoffRequestApproveParameter : IRestApiParameter
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
                    case ApiPath.Teams_TeamId_Schedule_TimeOffRequests_TimeOffRequestId_Approve: return $"/teams/{TeamId}/schedule/timeOffRequests/{TimeOffRequestId}/approve";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimeOffRequests_TimeOffRequestId_Approve,
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
    public partial class TimeoffRequestApproveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-approve?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-approve?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffRequestApproveResponse> TimeoffRequestApproveAsync()
        {
            var p = new TimeoffRequestApproveParameter();
            return await this.SendAsync<TimeoffRequestApproveParameter, TimeoffRequestApproveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-approve?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffRequestApproveResponse> TimeoffRequestApproveAsync(CancellationToken cancellationToken)
        {
            var p = new TimeoffRequestApproveParameter();
            return await this.SendAsync<TimeoffRequestApproveParameter, TimeoffRequestApproveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-approve?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffRequestApproveResponse> TimeoffRequestApproveAsync(TimeoffRequestApproveParameter parameter)
        {
            return await this.SendAsync<TimeoffRequestApproveParameter, TimeoffRequestApproveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffrequest-approve?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffRequestApproveResponse> TimeoffRequestApproveAsync(TimeoffRequestApproveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TimeoffRequestApproveParameter, TimeoffRequestApproveResponse>(parameter, cancellationToken);
        }
    }
}
