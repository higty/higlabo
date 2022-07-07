using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TimeoffreasonPutParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string TeamId { get; set; }
        public string TimeOffReasonId { get; set; }
    }
    public partial class TimeoffreasonPutResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/timeoffreason-put?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonPutResponse> TimeoffreasonPutAsync()
        {
            var p = new TimeoffreasonPutParameter();
            return await this.SendAsync<TimeoffreasonPutParameter, TimeoffreasonPutResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffreason-put?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonPutResponse> TimeoffreasonPutAsync(CancellationToken cancellationToken)
        {
            var p = new TimeoffreasonPutParameter();
            return await this.SendAsync<TimeoffreasonPutParameter, TimeoffreasonPutResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffreason-put?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonPutResponse> TimeoffreasonPutAsync(TimeoffreasonPutParameter parameter)
        {
            return await this.SendAsync<TimeoffreasonPutParameter, TimeoffreasonPutResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffreason-put?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonPutResponse> TimeoffreasonPutAsync(TimeoffreasonPutParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TimeoffreasonPutParameter, TimeoffreasonPutResponse>(parameter, cancellationToken);
        }
    }
}
