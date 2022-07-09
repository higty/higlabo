using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupUpdateThreadParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? GroupsId { get; set; }
            public string? ThreadsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Threads_Id: return $"/groups/{GroupsId}/threads/{ThreadsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_Threads_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class GroupUpdateThreadResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-update-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupUpdateThreadResponse> GroupUpdateThreadAsync()
        {
            var p = new GroupUpdateThreadParameter();
            return await this.SendAsync<GroupUpdateThreadParameter, GroupUpdateThreadResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-update-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupUpdateThreadResponse> GroupUpdateThreadAsync(CancellationToken cancellationToken)
        {
            var p = new GroupUpdateThreadParameter();
            return await this.SendAsync<GroupUpdateThreadParameter, GroupUpdateThreadResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-update-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupUpdateThreadResponse> GroupUpdateThreadAsync(GroupUpdateThreadParameter parameter)
        {
            return await this.SendAsync<GroupUpdateThreadParameter, GroupUpdateThreadResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-update-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupUpdateThreadResponse> GroupUpdateThreadAsync(GroupUpdateThreadParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupUpdateThreadParameter, GroupUpdateThreadResponse>(parameter, cancellationToken);
        }
    }
}
