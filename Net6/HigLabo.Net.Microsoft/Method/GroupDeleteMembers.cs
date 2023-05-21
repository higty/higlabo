using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete-members?view=graph-rest-1.0
    /// </summary>
    public partial class GroupDeleteMembersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? GroupsId { get; set; }
            public string? MembersId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Members_Id_ref: return $"/groups/{GroupsId}/members/{MembersId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_Members_Id_ref,
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
    public partial class GroupDeleteMembersResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete-members?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteMembersResponse> GroupDeleteMembersAsync()
        {
            var p = new GroupDeleteMembersParameter();
            return await this.SendAsync<GroupDeleteMembersParameter, GroupDeleteMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteMembersResponse> GroupDeleteMembersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeleteMembersParameter();
            return await this.SendAsync<GroupDeleteMembersParameter, GroupDeleteMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteMembersResponse> GroupDeleteMembersAsync(GroupDeleteMembersParameter parameter)
        {
            return await this.SendAsync<GroupDeleteMembersParameter, GroupDeleteMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteMembersResponse> GroupDeleteMembersAsync(GroupDeleteMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeleteMembersParameter, GroupDeleteMembersResponse>(parameter, cancellationToken);
        }
    }
}
