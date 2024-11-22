using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
/// </summary>
public partial class EntitlementManagementListConnectedOrganizationsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations: return $"/identityGovernance/entitlementManagement/connectedOrganizations";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_EntitlementManagement_ConnectedOrganizations,
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
public partial class EntitlementManagementListConnectedOrganizationsResponse : RestApiResponse<ConnectedOrganization>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EntitlementManagementListConnectedOrganizationsResponse> EntitlementManagementListConnectedOrganizationsAsync()
    {
        var p = new EntitlementManagementListConnectedOrganizationsParameter();
        return await this.SendAsync<EntitlementManagementListConnectedOrganizationsParameter, EntitlementManagementListConnectedOrganizationsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EntitlementManagementListConnectedOrganizationsResponse> EntitlementManagementListConnectedOrganizationsAsync(CancellationToken cancellationToken)
    {
        var p = new EntitlementManagementListConnectedOrganizationsParameter();
        return await this.SendAsync<EntitlementManagementListConnectedOrganizationsParameter, EntitlementManagementListConnectedOrganizationsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EntitlementManagementListConnectedOrganizationsResponse> EntitlementManagementListConnectedOrganizationsAsync(EntitlementManagementListConnectedOrganizationsParameter parameter)
    {
        return await this.SendAsync<EntitlementManagementListConnectedOrganizationsParameter, EntitlementManagementListConnectedOrganizationsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EntitlementManagementListConnectedOrganizationsResponse> EntitlementManagementListConnectedOrganizationsAsync(EntitlementManagementListConnectedOrganizationsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EntitlementManagementListConnectedOrganizationsParameter, EntitlementManagementListConnectedOrganizationsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ConnectedOrganization> EntitlementManagementListConnectedOrganizationsEnumerateAsync(EntitlementManagementListConnectedOrganizationsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<EntitlementManagementListConnectedOrganizationsParameter, EntitlementManagementListConnectedOrganizationsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ConnectedOrganization>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
