using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-get?view=graph-rest-1.0
    /// </summary>
    public partial class TimeoffReasonGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class TimeoffReasonGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffReasonGetResponse> TimeoffReasonGetAsync()
        {
            var p = new TimeoffReasonGetParameter();
            return await this.SendAsync<TimeoffReasonGetParameter, TimeoffReasonGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffReasonGetResponse> TimeoffReasonGetAsync(CancellationToken cancellationToken)
        {
            var p = new TimeoffReasonGetParameter();
            return await this.SendAsync<TimeoffReasonGetParameter, TimeoffReasonGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffReasonGetResponse> TimeoffReasonGetAsync(TimeoffReasonGetParameter parameter)
        {
            return await this.SendAsync<TimeoffReasonGetParameter, TimeoffReasonGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/timeoffreason-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TimeoffReasonGetResponse> TimeoffReasonGetAsync(TimeoffReasonGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TimeoffReasonGetParameter, TimeoffReasonGetResponse>(parameter, cancellationToken);
        }
    }
}
