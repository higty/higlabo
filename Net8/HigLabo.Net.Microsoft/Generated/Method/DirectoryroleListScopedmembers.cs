using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryrole-list-scopedmembers?view=graph-rest-1.0
/// </summary>
public partial class DirectoryroleListScopedMembersParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? RoleId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Directoryroles_RoleId_ScopedMembers: return $"/directoryroles/{RoleId}/scopedMembers";
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
        Directoryroles_RoleId_ScopedMembers,
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
public partial class DirectoryroleListScopedMembersResponse : RestApiResponse<ScopedRoleMembership>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryrole-list-scopedmembers?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-list-scopedmembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleListScopedMembersResponse> DirectoryroleListScopedMembersAsync()
    {
        var p = new DirectoryroleListScopedMembersParameter();
        return await this.SendAsync<DirectoryroleListScopedMembersParameter, DirectoryroleListScopedMembersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-list-scopedmembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleListScopedMembersResponse> DirectoryroleListScopedMembersAsync(CancellationToken cancellationToken)
    {
        var p = new DirectoryroleListScopedMembersParameter();
        return await this.SendAsync<DirectoryroleListScopedMembersParameter, DirectoryroleListScopedMembersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-list-scopedmembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleListScopedMembersResponse> DirectoryroleListScopedMembersAsync(DirectoryroleListScopedMembersParameter parameter)
    {
        return await this.SendAsync<DirectoryroleListScopedMembersParameter, DirectoryroleListScopedMembersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-list-scopedmembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleListScopedMembersResponse> DirectoryroleListScopedMembersAsync(DirectoryroleListScopedMembersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DirectoryroleListScopedMembersParameter, DirectoryroleListScopedMembersResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-list-scopedmembers?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ScopedRoleMembership> DirectoryroleListScopedMembersEnumerateAsync(DirectoryroleListScopedMembersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DirectoryroleListScopedMembersParameter, DirectoryroleListScopedMembersResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ScopedRoleMembership>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
