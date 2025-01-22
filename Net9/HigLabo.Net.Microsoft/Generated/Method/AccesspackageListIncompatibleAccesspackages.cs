using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatibleaccesspackages?view=graph-rest-1.0
/// </summary>
public partial class AccessPackageListIncompatibleAccessPackagesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleAccessPackages: return $"/identityGovernance/entitlementManagement/accessPackages/{Id}/incompatibleAccessPackages";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleAccessPackages,
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
public partial class AccessPackageListIncompatibleAccessPackagesResponse : RestApiResponse<AccessPackage>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatibleaccesspackages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatibleaccesspackages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageListIncompatibleAccessPackagesResponse> AccessPackageListIncompatibleAccessPackagesAsync()
    {
        var p = new AccessPackageListIncompatibleAccessPackagesParameter();
        return await this.SendAsync<AccessPackageListIncompatibleAccessPackagesParameter, AccessPackageListIncompatibleAccessPackagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatibleaccesspackages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageListIncompatibleAccessPackagesResponse> AccessPackageListIncompatibleAccessPackagesAsync(CancellationToken cancellationToken)
    {
        var p = new AccessPackageListIncompatibleAccessPackagesParameter();
        return await this.SendAsync<AccessPackageListIncompatibleAccessPackagesParameter, AccessPackageListIncompatibleAccessPackagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatibleaccesspackages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageListIncompatibleAccessPackagesResponse> AccessPackageListIncompatibleAccessPackagesAsync(AccessPackageListIncompatibleAccessPackagesParameter parameter)
    {
        return await this.SendAsync<AccessPackageListIncompatibleAccessPackagesParameter, AccessPackageListIncompatibleAccessPackagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatibleaccesspackages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageListIncompatibleAccessPackagesResponse> AccessPackageListIncompatibleAccessPackagesAsync(AccessPackageListIncompatibleAccessPackagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessPackageListIncompatibleAccessPackagesParameter, AccessPackageListIncompatibleAccessPackagesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatibleaccesspackages?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AccessPackage> AccessPackageListIncompatibleAccessPackagesEnumerateAsync(AccessPackageListIncompatibleAccessPackagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AccessPackageListIncompatibleAccessPackagesParameter, AccessPackageListIncompatibleAccessPackagesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AccessPackage>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
