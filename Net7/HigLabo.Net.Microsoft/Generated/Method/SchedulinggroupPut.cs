using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedulinggroup-put?view=graph-rest-1.0
    /// </summary>
    public partial class SchedulingGroupPutParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? SchedulingGroupId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_SchedulingGroups_SchedulingGroupId: return $"/teams/{TeamId}/schedule/schedulingGroups/{SchedulingGroupId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Schedule_SchedulingGroups_SchedulingGroupId,
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
    public partial class SchedulingGroupPutResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsActive { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string[]? UserIds { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schedulinggroup-put?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedulinggroup-put?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulingGroupPutResponse> SchedulingGroupPutAsync()
        {
            var p = new SchedulingGroupPutParameter();
            return await this.SendAsync<SchedulingGroupPutParameter, SchedulingGroupPutResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedulinggroup-put?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulingGroupPutResponse> SchedulingGroupPutAsync(CancellationToken cancellationToken)
        {
            var p = new SchedulingGroupPutParameter();
            return await this.SendAsync<SchedulingGroupPutParameter, SchedulingGroupPutResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedulinggroup-put?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulingGroupPutResponse> SchedulingGroupPutAsync(SchedulingGroupPutParameter parameter)
        {
            return await this.SendAsync<SchedulingGroupPutParameter, SchedulingGroupPutResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schedulinggroup-put?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchedulingGroupPutResponse> SchedulingGroupPutAsync(SchedulingGroupPutParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchedulingGroupPutParameter, SchedulingGroupPutResponse>(parameter, cancellationToken);
        }
    }
}
