using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TimeoffDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimesOff_TimeOffId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_TimesOff_TimeOffId: return $"/teams/{TeamId}/schedule/timesOff/{TimeOffId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string TeamId { get; set; }
        public string TimeOffId { get; set; }
    }
    public partial class TimeoffDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoff-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffDeleteResponse> TimeoffDeleteAsync()
        {
            var p = new TimeoffDeleteParameter();
            return await this.SendAsync<TimeoffDeleteParameter, TimeoffDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoff-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffDeleteResponse> TimeoffDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TimeoffDeleteParameter();
            return await this.SendAsync<TimeoffDeleteParameter, TimeoffDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoff-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffDeleteResponse> TimeoffDeleteAsync(TimeoffDeleteParameter parameter)
        {
            return await this.SendAsync<TimeoffDeleteParameter, TimeoffDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoff-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffDeleteResponse> TimeoffDeleteAsync(TimeoffDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TimeoffDeleteParameter, TimeoffDeleteResponse>(parameter, cancellationToken);
        }
    }
}
