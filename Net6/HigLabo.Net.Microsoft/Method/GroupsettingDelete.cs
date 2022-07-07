using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupsettingDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            GroupSettings_GroupSettingId,
            Groups_GroupId_Settings_GroupSettingId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.GroupSettings_GroupSettingId: return $"/groupSettings/{GroupSettingId}";
                    case ApiPath.Groups_GroupId_Settings_GroupSettingId: return $"/groups/{GroupId}/settings/{GroupSettingId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string GroupSettingId { get; set; }
        public string GroupId { get; set; }
    }
    public partial class GroupsettingDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsetting-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingDeleteResponse> GroupsettingDeleteAsync()
        {
            var p = new GroupsettingDeleteParameter();
            return await this.SendAsync<GroupsettingDeleteParameter, GroupsettingDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsetting-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingDeleteResponse> GroupsettingDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new GroupsettingDeleteParameter();
            return await this.SendAsync<GroupsettingDeleteParameter, GroupsettingDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsetting-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingDeleteResponse> GroupsettingDeleteAsync(GroupsettingDeleteParameter parameter)
        {
            return await this.SendAsync<GroupsettingDeleteParameter, GroupsettingDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsetting-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingDeleteResponse> GroupsettingDeleteAsync(GroupsettingDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupsettingDeleteParameter, GroupsettingDeleteResponse>(parameter, cancellationToken);
        }
    }
}
