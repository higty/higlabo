using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/tenantappmanagementpolicy-get?view=graph-rest-1.0
/// </summary>
public partial class TenantappManagementPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_DefaultAppManagementPolicy: return $"/policies/defaultAppManagementPolicy";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Policies_DefaultAppManagementPolicy,
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
public partial class TenantappManagementPolicyGetResponse : RestApiResponse
{
    public AppManagementConfiguration? ApplicationRestrictions { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsEnabled { get; set; }
    public AppManagementConfiguration? ServicePrincipalRestrictions { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/tenantappmanagementpolicy-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tenantappmanagementpolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TenantappManagementPolicyGetResponse> TenantappManagementPolicyGetAsync()
    {
        var p = new TenantappManagementPolicyGetParameter();
        return await this.SendAsync<TenantappManagementPolicyGetParameter, TenantappManagementPolicyGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tenantappmanagementpolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TenantappManagementPolicyGetResponse> TenantappManagementPolicyGetAsync(CancellationToken cancellationToken)
    {
        var p = new TenantappManagementPolicyGetParameter();
        return await this.SendAsync<TenantappManagementPolicyGetParameter, TenantappManagementPolicyGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tenantappmanagementpolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TenantappManagementPolicyGetResponse> TenantappManagementPolicyGetAsync(TenantappManagementPolicyGetParameter parameter)
    {
        return await this.SendAsync<TenantappManagementPolicyGetParameter, TenantappManagementPolicyGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tenantappmanagementpolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TenantappManagementPolicyGetResponse> TenantappManagementPolicyGetAsync(TenantappManagementPolicyGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TenantappManagementPolicyGetParameter, TenantappManagementPolicyGetResponse>(parameter, cancellationToken);
    }
}
