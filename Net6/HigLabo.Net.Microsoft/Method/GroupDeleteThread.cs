using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupDeleteThreadParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class GroupDeleteThreadResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteThreadResponse> GroupDeleteThreadAsync()
        {
            var p = new GroupDeleteThreadParameter();
            return await this.SendAsync<GroupDeleteThreadParameter, GroupDeleteThreadResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteThreadResponse> GroupDeleteThreadAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeleteThreadParameter();
            return await this.SendAsync<GroupDeleteThreadParameter, GroupDeleteThreadResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteThreadResponse> GroupDeleteThreadAsync(GroupDeleteThreadParameter parameter)
        {
            return await this.SendAsync<GroupDeleteThreadParameter, GroupDeleteThreadResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-thread?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteThreadResponse> GroupDeleteThreadAsync(GroupDeleteThreadParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeleteThreadParameter, GroupDeleteThreadResponse>(parameter, cancellationToken);
        }
    }
}
