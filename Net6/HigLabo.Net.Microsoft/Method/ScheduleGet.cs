using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ScheduleGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            Id,
            Enabled,
            TimeZone,
            ProvisionStatus,
            ProvisionStatusCode,
            TimeClockEnabled,
            OpenShiftsEnabled,
            SwapShiftsRequestsEnabled,
            OfferShiftRequestsEnabled,
            TimeOffRequestsEnabled,
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule: return $"/teams/{TeamId}/schedule";
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
    }
    public partial class ScheduleGetResponse : RestApiResponse
    {
        public enum ScheduleOperationStatus
        {
            NotStarted,
            Running,
            Completed,
            Failed,
        }

        public string? Id { get; set; }
        public bool? Enabled { get; set; }
        public string? TimeZone { get; set; }
        public ScheduleOperationStatus ProvisionStatus { get; set; }
        public string? ProvisionStatusCode { get; set; }
        public bool? TimeClockEnabled { get; set; }
        public bool? OpenShiftsEnabled { get; set; }
        public bool? SwapShiftsRequestsEnabled { get; set; }
        public bool? OfferShiftRequestsEnabled { get; set; }
        public bool? TimeOffRequestsEnabled { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleGetResponse> ScheduleGetAsync()
        {
            var p = new ScheduleGetParameter();
            return await this.SendAsync<ScheduleGetParameter, ScheduleGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleGetResponse> ScheduleGetAsync(CancellationToken cancellationToken)
        {
            var p = new ScheduleGetParameter();
            return await this.SendAsync<ScheduleGetParameter, ScheduleGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleGetResponse> ScheduleGetAsync(ScheduleGetParameter parameter)
        {
            return await this.SendAsync<ScheduleGetParameter, ScheduleGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleGetResponse> ScheduleGetAsync(ScheduleGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ScheduleGetParameter, ScheduleGetResponse>(parameter, cancellationToken);
        }
    }
}
