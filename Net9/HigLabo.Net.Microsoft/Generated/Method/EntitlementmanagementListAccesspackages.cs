using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
/// </summary>
public partial class EntitlementManagementListAccessPackagesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages: return $"/identityGovernance/entitlementManagement/accessPackages";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_EntitlementManagement_AccessPackages,
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
public partial class EntitlementManagementListAccessPackagesResponse : RestApiResponse<AccessPackage>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EntitlementManagementListAccessPackagesResponse> EntitlementManagementListAccessPackagesAsync()
    {
        var p = new EntitlementManagementListAccessPackagesParameter();
        return await this.SendAsync<EntitlementManagementListAccessPackagesParameter, EntitlementManagementListAccessPackagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EntitlementManagementListAccessPackagesResponse> EntitlementManagementListAccessPackagesAsync(CancellationToken cancellationToken)
    {
        var p = new EntitlementManagementListAccessPackagesParameter();
        return await this.SendAsync<EntitlementManagementListAccessPackagesParameter, EntitlementManagementListAccessPackagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EntitlementManagementListAccessPackagesResponse> EntitlementManagementListAccessPackagesAsync(EntitlementManagementListAccessPackagesParameter parameter)
    {
        return await this.SendAsync<EntitlementManagementListAccessPackagesParameter, EntitlementManagementListAccessPackagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EntitlementManagementListAccessPackagesResponse> EntitlementManagementListAccessPackagesAsync(EntitlementManagementListAccessPackagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EntitlementManagementListAccessPackagesParameter, EntitlementManagementListAccessPackagesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AccessPackage> EntitlementManagementListAccessPackagesEnumerateAsync(EntitlementManagementListAccessPackagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<EntitlementManagementListAccessPackagesParameter, EntitlementManagementListAccessPackagesResponse>(parameter, cancellationToken);
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
