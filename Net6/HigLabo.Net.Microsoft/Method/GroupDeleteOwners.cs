using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupDeleteOwnersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_Id_Owners_Id_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Owners_Id_ref: return $"/groups/{GroupsId}/owners/{OwnersId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string GroupsId { get; set; }
        public string OwnersId { get; set; }
    }
    public partial class GroupDeleteOwnersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteOwnersResponse> GroupDeleteOwnersAsync()
        {
            var p = new GroupDeleteOwnersParameter();
            return await this.SendAsync<GroupDeleteOwnersParameter, GroupDeleteOwnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteOwnersResponse> GroupDeleteOwnersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeleteOwnersParameter();
            return await this.SendAsync<GroupDeleteOwnersParameter, GroupDeleteOwnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteOwnersResponse> GroupDeleteOwnersAsync(GroupDeleteOwnersParameter parameter)
        {
            return await this.SendAsync<GroupDeleteOwnersParameter, GroupDeleteOwnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteOwnersResponse> GroupDeleteOwnersAsync(GroupDeleteOwnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeleteOwnersParameter, GroupDeleteOwnersResponse>(parameter, cancellationToken);
        }
    }
}
