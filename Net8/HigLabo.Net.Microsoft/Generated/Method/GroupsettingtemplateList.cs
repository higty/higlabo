using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/groupsettingtemplate-list?view=graph-rest-1.0
/// </summary>
public partial class GroupSettingTemplateListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.GroupSettingTemplates: return $"/groupSettingTemplates";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        GroupSettingTemplates,
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
public partial class GroupSettingTemplateListResponse : RestApiResponse<GroupSettingTemplate>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/groupsettingtemplate-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsettingtemplate-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupSettingTemplateListResponse> GroupSettingTemplateListAsync()
    {
        var p = new GroupSettingTemplateListParameter();
        return await this.SendAsync<GroupSettingTemplateListParameter, GroupSettingTemplateListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsettingtemplate-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupSettingTemplateListResponse> GroupSettingTemplateListAsync(CancellationToken cancellationToken)
    {
        var p = new GroupSettingTemplateListParameter();
        return await this.SendAsync<GroupSettingTemplateListParameter, GroupSettingTemplateListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsettingtemplate-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupSettingTemplateListResponse> GroupSettingTemplateListAsync(GroupSettingTemplateListParameter parameter)
    {
        return await this.SendAsync<GroupSettingTemplateListParameter, GroupSettingTemplateListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsettingtemplate-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupSettingTemplateListResponse> GroupSettingTemplateListAsync(GroupSettingTemplateListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupSettingTemplateListParameter, GroupSettingTemplateListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/groupsettingtemplate-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<GroupSettingTemplate> GroupSettingTemplateListEnumerateAsync(GroupSettingTemplateListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<GroupSettingTemplateListParameter, GroupSettingTemplateListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<GroupSettingTemplate>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
