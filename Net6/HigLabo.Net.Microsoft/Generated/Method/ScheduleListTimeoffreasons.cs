using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
    /// </summary>
    public partial class ScheduleListTimeoffreasonsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_TimeOffReasons: return $"/teams/{TeamId}/schedule/timeOffReasons";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            DisplayName,
            IconType,
            Id,
            IsActive,
            LastModifiedBy,
            LastModifiedDateTime,
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_TimeOffReasons,
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
    public partial class ScheduleListTimeoffreasonsResponse : RestApiResponse
    {
        public TimeOffReason[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListTimeoffreasonsResponse> ScheduleListTimeoffreasonsAsync()
        {
            var p = new ScheduleListTimeoffreasonsParameter();
            return await this.SendAsync<ScheduleListTimeoffreasonsParameter, ScheduleListTimeoffreasonsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListTimeoffreasonsResponse> ScheduleListTimeoffreasonsAsync(CancellationToken cancellationToken)
        {
            var p = new ScheduleListTimeoffreasonsParameter();
            return await this.SendAsync<ScheduleListTimeoffreasonsParameter, ScheduleListTimeoffreasonsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListTimeoffreasonsResponse> ScheduleListTimeoffreasonsAsync(ScheduleListTimeoffreasonsParameter parameter)
        {
            return await this.SendAsync<ScheduleListTimeoffreasonsParameter, ScheduleListTimeoffreasonsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedule-list-timeoffreasons?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListTimeoffreasonsResponse> ScheduleListTimeoffreasonsAsync(ScheduleListTimeoffreasonsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ScheduleListTimeoffreasonsParameter, ScheduleListTimeoffreasonsResponse>(parameter, cancellationToken);
        }
    }
}
