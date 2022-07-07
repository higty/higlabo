using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupDeleteMembersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_Id_Members_Id_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Members_Id_ref: return $"/groups/{GroupsId}/members/{MembersId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string GroupsId { get; set; }
        public string MembersId { get; set; }
    }
    public partial class GroupDeleteMembersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteMembersResponse> GroupDeleteMembersAsync()
        {
            var p = new GroupDeleteMembersParameter();
            return await this.SendAsync<GroupDeleteMembersParameter, GroupDeleteMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteMembersResponse> GroupDeleteMembersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeleteMembersParameter();
            return await this.SendAsync<GroupDeleteMembersParameter, GroupDeleteMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteMembersResponse> GroupDeleteMembersAsync(GroupDeleteMembersParameter parameter)
        {
            return await this.SendAsync<GroupDeleteMembersParameter, GroupDeleteMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteMembersResponse> GroupDeleteMembersAsync(GroupDeleteMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeleteMembersParameter, GroupDeleteMembersResponse>(parameter, cancellationToken);
        }
    }
}
