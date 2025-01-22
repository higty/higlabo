using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-scopedrolemembers?view=graph-rest-1.0
/// </summary>
public partial class AdministrativeunitListScopedroleMembersParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Directory_AdministrativeUnits_Id_ScopedRoleMembers: return $"/directory/administrativeUnits/{Id}/scopedRoleMembers";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Directory_AdministrativeUnits_Id_ScopedRoleMembers,
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
public partial class AdministrativeunitListScopedroleMembersResponse : RestApiResponse<ScopedRoleMembership>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-scopedrolemembers?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-scopedrolemembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitListScopedroleMembersResponse> AdministrativeunitListScopedroleMembersAsync()
    {
        var p = new AdministrativeunitListScopedroleMembersParameter();
        return await this.SendAsync<AdministrativeunitListScopedroleMembersParameter, AdministrativeunitListScopedroleMembersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-scopedrolemembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitListScopedroleMembersResponse> AdministrativeunitListScopedroleMembersAsync(CancellationToken cancellationToken)
    {
        var p = new AdministrativeunitListScopedroleMembersParameter();
        return await this.SendAsync<AdministrativeunitListScopedroleMembersParameter, AdministrativeunitListScopedroleMembersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-scopedrolemembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitListScopedroleMembersResponse> AdministrativeunitListScopedroleMembersAsync(AdministrativeunitListScopedroleMembersParameter parameter)
    {
        return await this.SendAsync<AdministrativeunitListScopedroleMembersParameter, AdministrativeunitListScopedroleMembersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-scopedrolemembers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitListScopedroleMembersResponse> AdministrativeunitListScopedroleMembersAsync(AdministrativeunitListScopedroleMembersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AdministrativeunitListScopedroleMembersParameter, AdministrativeunitListScopedroleMembersResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-scopedrolemembers?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ScopedRoleMembership> AdministrativeunitListScopedroleMembersEnumerateAsync(AdministrativeunitListScopedroleMembersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AdministrativeunitListScopedroleMembersParameter, AdministrativeunitListScopedroleMembersResponse>(parameter, cancellationToken);
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
