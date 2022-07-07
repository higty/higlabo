using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ScheduleListSchedulinggroupsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_SchedulingGroups,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_SchedulingGroups: return $"/teams/{TeamId}/schedule/schedulingGroups";
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
    public partial class ScheduleListSchedulinggroupsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/schedulinggroup?view=graph-rest-1.0
        /// </summary>
        public partial class SchedulingGroup
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public bool? IsActive { get; set; }
            public string[]? UserIds { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public IdentitySet? LastModifiedBy { get; set; }
        }

        public SchedulingGroup[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-schedulinggroups?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListSchedulinggroupsResponse> ScheduleListSchedulinggroupsAsync()
        {
            var p = new ScheduleListSchedulinggroupsParameter();
            return await this.SendAsync<ScheduleListSchedulinggroupsParameter, ScheduleListSchedulinggroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-schedulinggroups?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListSchedulinggroupsResponse> ScheduleListSchedulinggroupsAsync(CancellationToken cancellationToken)
        {
            var p = new ScheduleListSchedulinggroupsParameter();
            return await this.SendAsync<ScheduleListSchedulinggroupsParameter, ScheduleListSchedulinggroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-schedulinggroups?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListSchedulinggroupsResponse> ScheduleListSchedulinggroupsAsync(ScheduleListSchedulinggroupsParameter parameter)
        {
            return await this.SendAsync<ScheduleListSchedulinggroupsParameter, ScheduleListSchedulinggroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedule-list-schedulinggroups?view=graph-rest-1.0
        /// </summary>
        public async Task<ScheduleListSchedulinggroupsResponse> ScheduleListSchedulinggroupsAsync(ScheduleListSchedulinggroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ScheduleListSchedulinggroupsParameter, ScheduleListSchedulinggroupsResponse>(parameter, cancellationToken);
        }
    }
}
