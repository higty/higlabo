using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupDeleteThreadParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_Id_Threads_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Threads_Id: return $"/groups/{GroupsId}/threads/{ThreadsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string GroupsId { get; set; }
        public string ThreadsId { get; set; }
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
