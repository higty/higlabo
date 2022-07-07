using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SchedulinggroupGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_SchedulingGroups_SchedulingGroupId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_SchedulingGroups_SchedulingGroupId: return $"/teams/{TeamId}/schedule/schedulingGroups/{SchedulingGroupId}";
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
        public string SchedulingGroupId { get; set; }
    }
    public partial class SchedulinggroupGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsActive { get; set; }
        public string[]? UserIds { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedulinggroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulinggroupGetResponse> SchedulinggroupGetAsync()
        {
            var p = new SchedulinggroupGetParameter();
            return await this.SendAsync<SchedulinggroupGetParameter, SchedulinggroupGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedulinggroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulinggroupGetResponse> SchedulinggroupGetAsync(CancellationToken cancellationToken)
        {
            var p = new SchedulinggroupGetParameter();
            return await this.SendAsync<SchedulinggroupGetParameter, SchedulinggroupGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedulinggroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulinggroupGetResponse> SchedulinggroupGetAsync(SchedulinggroupGetParameter parameter)
        {
            return await this.SendAsync<SchedulinggroupGetParameter, SchedulinggroupGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedulinggroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulinggroupGetResponse> SchedulinggroupGetAsync(SchedulinggroupGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchedulinggroupGetParameter, SchedulinggroupGetResponse>(parameter, cancellationToken);
        }
    }
}
