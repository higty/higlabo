using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SchedulinggroupDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string TeamId { get; set; }
        public string SchedulingGroupId { get; set; }
    }
    public partial class SchedulinggroupDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedulinggroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulinggroupDeleteResponse> SchedulinggroupDeleteAsync()
        {
            var p = new SchedulinggroupDeleteParameter();
            return await this.SendAsync<SchedulinggroupDeleteParameter, SchedulinggroupDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedulinggroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulinggroupDeleteResponse> SchedulinggroupDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new SchedulinggroupDeleteParameter();
            return await this.SendAsync<SchedulinggroupDeleteParameter, SchedulinggroupDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedulinggroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulinggroupDeleteResponse> SchedulinggroupDeleteAsync(SchedulinggroupDeleteParameter parameter)
        {
            return await this.SendAsync<SchedulinggroupDeleteParameter, SchedulinggroupDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schedulinggroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SchedulinggroupDeleteResponse> SchedulinggroupDeleteAsync(SchedulinggroupDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchedulinggroupDeleteParameter, SchedulinggroupDeleteResponse>(parameter, cancellationToken);
        }
    }
}
