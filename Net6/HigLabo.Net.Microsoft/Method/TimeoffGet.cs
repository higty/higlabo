using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TimeoffGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string TeamId { get; set; }
        public string TimeOffId { get; set; }
    }
    public partial class TimeoffGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/timeoff-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffGetResponse> TimeoffGetAsync()
        {
            var p = new TimeoffGetParameter();
            return await this.SendAsync<TimeoffGetParameter, TimeoffGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoff-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffGetResponse> TimeoffGetAsync(CancellationToken cancellationToken)
        {
            var p = new TimeoffGetParameter();
            return await this.SendAsync<TimeoffGetParameter, TimeoffGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoff-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffGetResponse> TimeoffGetAsync(TimeoffGetParameter parameter)
        {
            return await this.SendAsync<TimeoffGetParameter, TimeoffGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoff-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffGetResponse> TimeoffGetAsync(TimeoffGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TimeoffGetParameter, TimeoffGetResponse>(parameter, cancellationToken);
        }
    }
}
