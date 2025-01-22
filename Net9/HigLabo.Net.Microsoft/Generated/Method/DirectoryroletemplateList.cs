using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
/// </summary>
public partial class DirectoryroleTemplateListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.DirectoryRoleTemplates: return $"/directoryRoleTemplates";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        DirectoryRoleTemplates,
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
public partial class DirectoryroleTemplateListResponse : RestApiResponse<DirectoryRoleTemplate>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleTemplateListResponse> DirectoryroleTemplateListAsync()
    {
        var p = new DirectoryroleTemplateListParameter();
        return await this.SendAsync<DirectoryroleTemplateListParameter, DirectoryroleTemplateListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleTemplateListResponse> DirectoryroleTemplateListAsync(CancellationToken cancellationToken)
    {
        var p = new DirectoryroleTemplateListParameter();
        return await this.SendAsync<DirectoryroleTemplateListParameter, DirectoryroleTemplateListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleTemplateListResponse> DirectoryroleTemplateListAsync(DirectoryroleTemplateListParameter parameter)
    {
        return await this.SendAsync<DirectoryroleTemplateListParameter, DirectoryroleTemplateListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleTemplateListResponse> DirectoryroleTemplateListAsync(DirectoryroleTemplateListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DirectoryroleTemplateListParameter, DirectoryroleTemplateListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryRoleTemplate> DirectoryroleTemplateListEnumerateAsync(DirectoryroleTemplateListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DirectoryroleTemplateListParameter, DirectoryroleTemplateListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<DirectoryRoleTemplate>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
