using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsetting-delete?view=graph-rest-1.0
    /// </summary>
    public partial class GroupSettingDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? GroupSettingId { get; set; }
            public string? GroupId { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class GroupSettingDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsetting-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/groupsetting-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupSettingDeleteResponse> GroupSettingDeleteAsync()
        {
            var p = new GroupSettingDeleteParameter();
            return await this.SendAsync<GroupSettingDeleteParameter, GroupSettingDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/groupsetting-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupSettingDeleteResponse> GroupSettingDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new GroupSettingDeleteParameter();
            return await this.SendAsync<GroupSettingDeleteParameter, GroupSettingDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/groupsetting-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupSettingDeleteResponse> GroupSettingDeleteAsync(GroupSettingDeleteParameter parameter)
        {
            return await this.SendAsync<GroupSettingDeleteParameter, GroupSettingDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/groupsetting-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupSettingDeleteResponse> GroupSettingDeleteAsync(GroupSettingDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupSettingDeleteParameter, GroupSettingDeleteResponse>(parameter, cancellationToken);
        }
    }
}
