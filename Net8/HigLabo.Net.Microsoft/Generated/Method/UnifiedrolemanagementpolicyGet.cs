using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-get?view=graph-rest-1.0
/// </summary>
public partial class UnifiedroleManagementPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? UnifiedRoleManagementPolicyId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_RoleManagementPolicies_UnifiedRoleManagementPolicyId: return $"/policies/roleManagementPolicies/{UnifiedRoleManagementPolicyId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Policies_RoleManagementPolicies_UnifiedRoleManagementPolicyId,
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
public partial class UnifiedroleManagementPolicyGetResponse : RestApiResponse
{
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsOrganizationDefault { get; set; }
    public Identity? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? ScopeId { get; set; }
    public string? ScopeType { get; set; }
    public UnifiedRoleManagementPolicyRule[]? EffectiveRules { get; set; }
    public UnifiedRoleManagementPolicyRule[]? Rules { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleManagementPolicyGetResponse> UnifiedroleManagementPolicyGetAsync()
    {
        var p = new UnifiedroleManagementPolicyGetParameter();
        return await this.SendAsync<UnifiedroleManagementPolicyGetParameter, UnifiedroleManagementPolicyGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleManagementPolicyGetResponse> UnifiedroleManagementPolicyGetAsync(CancellationToken cancellationToken)
    {
        var p = new UnifiedroleManagementPolicyGetParameter();
        return await this.SendAsync<UnifiedroleManagementPolicyGetParameter, UnifiedroleManagementPolicyGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleManagementPolicyGetResponse> UnifiedroleManagementPolicyGetAsync(UnifiedroleManagementPolicyGetParameter parameter)
    {
        return await this.SendAsync<UnifiedroleManagementPolicyGetParameter, UnifiedroleManagementPolicyGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleManagementPolicyGetResponse> UnifiedroleManagementPolicyGetAsync(UnifiedroleManagementPolicyGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UnifiedroleManagementPolicyGetParameter, UnifiedroleManagementPolicyGetResponse>(parameter, cancellationToken);
    }
}
