using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
/// </summary>
public partial class ServicePrincipalListDelegatedPermissionClassificationsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.ServicePrincipals_Id_DelegatedPermissionClassifications: return $"/servicePrincipals/{Id}/delegatedPermissionClassifications";
                case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        ServicePrincipals_Id_DelegatedPermissionClassifications,
        ServicePrincipals,
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
public partial class ServicePrincipalListDelegatedPermissionClassificationsResponse : RestApiResponse<DelegatedPermissionClassification>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListDelegatedPermissionClassificationsResponse> ServicePrincipalListDelegatedPermissionClassificationsAsync()
    {
        var p = new ServicePrincipalListDelegatedPermissionClassificationsParameter();
        return await this.SendAsync<ServicePrincipalListDelegatedPermissionClassificationsParameter, ServicePrincipalListDelegatedPermissionClassificationsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListDelegatedPermissionClassificationsResponse> ServicePrincipalListDelegatedPermissionClassificationsAsync(CancellationToken cancellationToken)
    {
        var p = new ServicePrincipalListDelegatedPermissionClassificationsParameter();
        return await this.SendAsync<ServicePrincipalListDelegatedPermissionClassificationsParameter, ServicePrincipalListDelegatedPermissionClassificationsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListDelegatedPermissionClassificationsResponse> ServicePrincipalListDelegatedPermissionClassificationsAsync(ServicePrincipalListDelegatedPermissionClassificationsParameter parameter)
    {
        return await this.SendAsync<ServicePrincipalListDelegatedPermissionClassificationsParameter, ServicePrincipalListDelegatedPermissionClassificationsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ServicePrincipalListDelegatedPermissionClassificationsResponse> ServicePrincipalListDelegatedPermissionClassificationsAsync(ServicePrincipalListDelegatedPermissionClassificationsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ServicePrincipalListDelegatedPermissionClassificationsParameter, ServicePrincipalListDelegatedPermissionClassificationsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-delegatedpermissionclassifications?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DelegatedPermissionClassification> ServicePrincipalListDelegatedPermissionClassificationsEnumerateAsync(ServicePrincipalListDelegatedPermissionClassificationsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ServicePrincipalListDelegatedPermissionClassificationsParameter, ServicePrincipalListDelegatedPermissionClassificationsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<DelegatedPermissionClassification>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
