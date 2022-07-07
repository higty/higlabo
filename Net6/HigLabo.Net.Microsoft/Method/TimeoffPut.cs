using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TimeoffPutParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string TeamId { get; set; }
        public string TimeOffId { get; set; }
    }
    public partial class TimeoffPutResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public TimeOffItem? SharedTimeOff { get; set; }
        public TimeOffItem? DraftTimeOff { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoff-put?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffPutResponse> TimeoffPutAsync()
        {
            var p = new TimeoffPutParameter();
            return await this.SendAsync<TimeoffPutParameter, TimeoffPutResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoff-put?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffPutResponse> TimeoffPutAsync(CancellationToken cancellationToken)
        {
            var p = new TimeoffPutParameter();
            return await this.SendAsync<TimeoffPutParameter, TimeoffPutResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoff-put?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffPutResponse> TimeoffPutAsync(TimeoffPutParameter parameter)
        {
            return await this.SendAsync<TimeoffPutParameter, TimeoffPutResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoff-put?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffPutResponse> TimeoffPutAsync(TimeoffPutParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TimeoffPutParameter, TimeoffPutResponse>(parameter, cancellationToken);
        }
    }
}
