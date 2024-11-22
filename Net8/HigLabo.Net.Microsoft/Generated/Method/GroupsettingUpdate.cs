using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/groupsetting-update?view=graph-rest-1.0
/// </summary>
public partial class GroupSettingUpdateParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public SettingValue[]? Values { get; set; }
}
public partial class GroupSettingUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/groupsetting-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsetting-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupSettingUpdateResponse> GroupSettingUpdateAsync()
    {
        var p = new GroupSettingUpdateParameter();
        return await this.SendAsync<GroupSettingUpdateParameter, GroupSettingUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsetting-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupSettingUpdateResponse> GroupSettingUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new GroupSettingUpdateParameter();
        return await this.SendAsync<GroupSettingUpdateParameter, GroupSettingUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsetting-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupSettingUpdateResponse> GroupSettingUpdateAsync(GroupSettingUpdateParameter parameter)
    {
        return await this.SendAsync<GroupSettingUpdateParameter, GroupSettingUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsetting-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupSettingUpdateResponse> GroupSettingUpdateAsync(GroupSettingUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupSettingUpdateParameter, GroupSettingUpdateResponse>(parameter, cancellationToken);
    }
}
