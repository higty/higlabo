using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatiblegroups?view=graph-rest-1.0
/// </summary>
public partial class AccessPackageListIncompatibleGroupsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleGroups: return $"/identityGovernance/entitlementManagement/accessPackages/{Id}/incompatibleGroups";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleGroups,
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
public partial class AccessPackageListIncompatibleGroupsResponse : RestApiResponse<Group>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatiblegroups?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatiblegroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageListIncompatibleGroupsResponse> AccessPackageListIncompatibleGroupsAsync()
    {
        var p = new AccessPackageListIncompatibleGroupsParameter();
        return await this.SendAsync<AccessPackageListIncompatibleGroupsParameter, AccessPackageListIncompatibleGroupsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatiblegroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageListIncompatibleGroupsResponse> AccessPackageListIncompatibleGroupsAsync(CancellationToken cancellationToken)
    {
        var p = new AccessPackageListIncompatibleGroupsParameter();
        return await this.SendAsync<AccessPackageListIncompatibleGroupsParameter, AccessPackageListIncompatibleGroupsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatiblegroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageListIncompatibleGroupsResponse> AccessPackageListIncompatibleGroupsAsync(AccessPackageListIncompatibleGroupsParameter parameter)
    {
        return await this.SendAsync<AccessPackageListIncompatibleGroupsParameter, AccessPackageListIncompatibleGroupsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatiblegroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageListIncompatibleGroupsResponse> AccessPackageListIncompatibleGroupsAsync(AccessPackageListIncompatibleGroupsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessPackageListIncompatibleGroupsParameter, AccessPackageListIncompatibleGroupsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatiblegroups?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Group> AccessPackageListIncompatibleGroupsEnumerateAsync(AccessPackageListIncompatibleGroupsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AccessPackageListIncompatibleGroupsParameter, AccessPackageListIncompatibleGroupsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Group>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
