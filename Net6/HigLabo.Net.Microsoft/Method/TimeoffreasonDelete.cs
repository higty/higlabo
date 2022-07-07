using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TimeoffreasonDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string TeamId { get; set; }
        public string TimeOffReasonId { get; set; }
    }
    public partial class TimeoffreasonDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffreason-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonDeleteResponse> TimeoffreasonDeleteAsync()
        {
            var p = new TimeoffreasonDeleteParameter();
            return await this.SendAsync<TimeoffreasonDeleteParameter, TimeoffreasonDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffreason-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonDeleteResponse> TimeoffreasonDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TimeoffreasonDeleteParameter();
            return await this.SendAsync<TimeoffreasonDeleteParameter, TimeoffreasonDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffreason-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonDeleteResponse> TimeoffreasonDeleteAsync(TimeoffreasonDeleteParameter parameter)
        {
            return await this.SendAsync<TimeoffreasonDeleteParameter, TimeoffreasonDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/timeoffreason-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonDeleteResponse> TimeoffreasonDeleteAsync(TimeoffreasonDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TimeoffreasonDeleteParameter, TimeoffreasonDeleteResponse>(parameter, cancellationToken);
        }
    }
}
