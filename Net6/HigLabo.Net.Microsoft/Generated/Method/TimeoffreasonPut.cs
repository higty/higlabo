using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-put?view=graph-rest-1.0
    /// </summary>
    public partial class TimeoffreasonPutParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? TimeOffReasonId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_TimeOffReasons_TimeOffReasonId: return $"/teams/{TeamId}/schedule/timeOffReasons/{TimeOffReasonId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimeOffReasons_TimeOffReasonId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
    }
    public partial class TimeoffreasonPutResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public TimeOffReasonIconType? IconType { get; set; }
        public string? Id { get; set; }
        public bool? IsActive { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-put?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-put?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonPutResponse> TimeoffreasonPutAsync()
        {
            var p = new TimeoffreasonPutParameter();
            return await this.SendAsync<TimeoffreasonPutParameter, TimeoffreasonPutResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-put?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonPutResponse> TimeoffreasonPutAsync(CancellationToken cancellationToken)
        {
            var p = new TimeoffreasonPutParameter();
            return await this.SendAsync<TimeoffreasonPutParameter, TimeoffreasonPutResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-put?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonPutResponse> TimeoffreasonPutAsync(TimeoffreasonPutParameter parameter)
        {
            return await this.SendAsync<TimeoffreasonPutParameter, TimeoffreasonPutResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-put?view=graph-rest-1.0
        /// </summary>
        public async Task<TimeoffreasonPutResponse> TimeoffreasonPutAsync(TimeoffreasonPutParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TimeoffreasonPutParameter, TimeoffreasonPutResponse>(parameter, cancellationToken);
        }
    }
}
