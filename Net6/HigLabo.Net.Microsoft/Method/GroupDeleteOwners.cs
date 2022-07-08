using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupDeleteOwnersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string GroupsId { get; set; }
            public string OwnersId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Owners_Id_ref: return $"/groups/{GroupsId}/owners/{OwnersId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_Owners_Id_ref,
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
