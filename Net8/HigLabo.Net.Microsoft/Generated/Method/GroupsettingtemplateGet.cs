using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/groupsettingtemplate-get?view=graph-rest-1.0
/// </summary>
public partial class GroupSettingTemplateGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.GroupSettingTemplates_Id: return $"/groupSettingTemplates/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        GroupSettingTemplates_Id,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class GroupSettingTemplateGetResponse : RestApiResponse
{
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public SettingTemplateValue[]? Values { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/groupsettingtemplate-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsettingtemplate-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupSettingTemplateGetResponse> GroupSettingTemplateGetAsync()
    {
        var p = new GroupSettingTemplateGetParameter();
        return await this.SendAsync<GroupSettingTemplateGetParameter, GroupSettingTemplateGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsettingtemplate-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupSettingTemplateGetResponse> GroupSettingTemplateGetAsync(CancellationToken cancellationToken)
    {
        var p = new GroupSettingTemplateGetParameter();
        return await this.SendAsync<GroupSettingTemplateGetParameter, GroupSettingTemplateGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsettingtemplate-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupSettingTemplateGetResponse> GroupSettingTemplateGetAsync(GroupSettingTemplateGetParameter parameter)
    {
        return await this.SendAsync<GroupSettingTemplateGetParameter, GroupSettingTemplateGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsettingtemplate-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupSettingTemplateGetResponse> GroupSettingTemplateGetAsync(GroupSettingTemplateGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupSettingTemplateGetParameter, GroupSettingTemplateGetResponse>(parameter, cancellationToken);
    }
}
