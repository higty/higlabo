using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-post-settings?view=graph-rest-1.0
/// </summary>
public partial class GroupPostSettingsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.GroupSettings: return $"/groupSettings";
                case ApiPath.Groups_Id_Settings: return $"/groups/{Id}/settings";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        GroupSettings,
        Groups_Id_Settings,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? TemplateId { get; set; }
    public SettingValue[]? Values { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
}
public partial class GroupPostSettingsResponse : RestApiResponse
{
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? TemplateId { get; set; }
    public SettingValue[]? Values { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-post-settings?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-settings?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupPostSettingsResponse> GroupPostSettingsAsync()
    {
        var p = new GroupPostSettingsParameter();
        return await this.SendAsync<GroupPostSettingsParameter, GroupPostSettingsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-settings?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupPostSettingsResponse> GroupPostSettingsAsync(CancellationToken cancellationToken)
    {
        var p = new GroupPostSettingsParameter();
        return await this.SendAsync<GroupPostSettingsParameter, GroupPostSettingsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-settings?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupPostSettingsResponse> GroupPostSettingsAsync(GroupPostSettingsParameter parameter)
    {
        return await this.SendAsync<GroupPostSettingsParameter, GroupPostSettingsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-settings?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupPostSettingsResponse> GroupPostSettingsAsync(GroupPostSettingsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupPostSettingsParameter, GroupPostSettingsResponse>(parameter, cancellationToken);
    }
}
