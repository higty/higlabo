using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryrole-get?view=graph-rest-1.0
/// </summary>
public partial class DirectoryroleGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? RoleId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.DirectoryRoles_RoleId: return $"/directoryRoles/{RoleId}";
                case ApiPath.DirectoryRoles: return $"/directoryRoles";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        DirectoryRoles_RoleId,
        DirectoryRoles,
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
public partial class DirectoryroleGetResponse : RestApiResponse
{
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? RoleTemplateId { get; set; }
    public DirectoryObject[]? Members { get; set; }
    public ScopedRoleMembership[]? ScopedMembers { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryrole-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleGetResponse> DirectoryroleGetAsync()
    {
        var p = new DirectoryroleGetParameter();
        return await this.SendAsync<DirectoryroleGetParameter, DirectoryroleGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleGetResponse> DirectoryroleGetAsync(CancellationToken cancellationToken)
    {
        var p = new DirectoryroleGetParameter();
        return await this.SendAsync<DirectoryroleGetParameter, DirectoryroleGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleGetResponse> DirectoryroleGetAsync(DirectoryroleGetParameter parameter)
    {
        return await this.SendAsync<DirectoryroleGetParameter, DirectoryroleGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleGetResponse> DirectoryroleGetAsync(DirectoryroleGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DirectoryroleGetParameter, DirectoryroleGetResponse>(parameter, cancellationToken);
    }
}
