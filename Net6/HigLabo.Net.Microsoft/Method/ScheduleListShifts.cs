using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ScheduleListShiftsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_Shifts: return $"/teams/{TeamId}/schedule/shifts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            UserId,
            SchedulingGroupId,
            SharedShift,
            DraftShift,
            CreatedDateTime,
            LastModifiedDateTime,
            LastModifiedBy,
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_Shifts,
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
    public partial class ScheduleListShiftsResponse : RestApiResponse
    {
        public Shift[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListShiftsResponse> ScheduleListShiftsAsync()
        {
            var p = new ScheduleListShiftsParameter();
            return await this.SendAsync<ScheduleListShiftsParameter, ScheduleListShiftsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListShiftsResponse> ScheduleListShiftsAsync(CancellationToken cancellationToken)
        {
            var p = new ScheduleListShiftsParameter();
            return await this.SendAsync<ScheduleListShiftsParameter, ScheduleListShiftsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListShiftsResponse> ScheduleListShiftsAsync(ScheduleListShiftsParameter parameter)
        {
            return await this.SendAsync<ScheduleListShiftsParameter, ScheduleListShiftsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-shifts?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListShiftsResponse> ScheduleListShiftsAsync(ScheduleListShiftsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ScheduleListShiftsParameter, ScheduleListShiftsResponse>(parameter, cancellationToken);
        }
    }
}
