using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SchedulinggroupPutParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string TeamId { get; set; }
        public string SchedulingGroupId { get; set; }
    }
    public partial class SchedulinggroupPutResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/schedulinggroup-put?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulinggroupPutResponse> SchedulinggroupPutAsync()
        {
            var p = new SchedulinggroupPutParameter();
            return await this.SendAsync<SchedulinggroupPutParameter, SchedulinggroupPutResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedulinggroup-put?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulinggroupPutResponse> SchedulinggroupPutAsync(CancellationToken cancellationToken)
        {
            var p = new SchedulinggroupPutParameter();
            return await this.SendAsync<SchedulinggroupPutParameter, SchedulinggroupPutResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedulinggroup-put?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulinggroupPutResponse> SchedulinggroupPutAsync(SchedulinggroupPutParameter parameter)
        {
            return await this.SendAsync<SchedulinggroupPutParameter, SchedulinggroupPutResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedulinggroup-put?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulinggroupPutResponse> SchedulinggroupPutAsync(SchedulinggroupPutParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchedulinggroupPutParameter, SchedulinggroupPutResponse>(parameter, cancellationToken);
        }
    }
}
