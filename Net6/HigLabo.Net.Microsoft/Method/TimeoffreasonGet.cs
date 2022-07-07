using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TimeoffreasonGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimeOffReasons_TimeOffReasonId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_TimeOffReasons_TimeOffReasonId: return $"/teams/{TeamId}/schedule/timeOffReasons/{TimeOffReasonId}";
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
        public string TimeOffReasonId { get; set; }
    }
    public partial class TimeoffreasonGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public TimeOffReasonIconType? IconType { get; set; }
        public bool? IsActive { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffreason-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonGetResponse> TimeoffreasonGetAsync()
        {
            var p = new TimeoffreasonGetParameter();
            return await this.SendAsync<TimeoffreasonGetParameter, TimeoffreasonGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffreason-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonGetResponse> TimeoffreasonGetAsync(CancellationToken cancellationToken)
        {
            var p = new TimeoffreasonGetParameter();
            return await this.SendAsync<TimeoffreasonGetParameter, TimeoffreasonGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffreason-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonGetResponse> TimeoffreasonGetAsync(TimeoffreasonGetParameter parameter)
        {
            return await this.SendAsync<TimeoffreasonGetParameter, TimeoffreasonGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffreason-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonGetResponse> TimeoffreasonGetAsync(TimeoffreasonGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TimeoffreasonGetParameter, TimeoffreasonGetResponse>(parameter, cancellationToken);
        }
    }
}
