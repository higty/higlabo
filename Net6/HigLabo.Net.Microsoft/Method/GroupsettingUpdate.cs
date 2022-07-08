using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupsettingUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string GroupSettingId { get; set; }
            public string GroupId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.GroupSettings_GroupSettingId: return $"/groupSettings/{GroupSettingId}";
                    case ApiPath.Groups_GroupId_Settings_GroupSettingId: return $"/groups/{GroupId}/settings/{GroupSettingId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            GroupSettings_GroupSettingId,
            Groups_GroupId_Settings_GroupSettingId,
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
        public SettingValue[]? Values { get; set; }
    }
    public partial class GroupsettingUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsetting-update?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingUpdateResponse> GroupsettingUpdateAsync()
        {
            var p = new GroupsettingUpdateParameter();
            return await this.SendAsync<GroupsettingUpdateParameter, GroupsettingUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsetting-update?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingUpdateResponse> GroupsettingUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new GroupsettingUpdateParameter();
            return await this.SendAsync<GroupsettingUpdateParameter, GroupsettingUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsetting-update?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingUpdateResponse> GroupsettingUpdateAsync(GroupsettingUpdateParameter parameter)
        {
            return await this.SendAsync<GroupsettingUpdateParameter, GroupsettingUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/groupsetting-update?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupsettingUpdateResponse> GroupsettingUpdateAsync(GroupsettingUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupsettingUpdateParameter, GroupsettingUpdateResponse>(parameter, cancellationToken);
        }
    }
}
