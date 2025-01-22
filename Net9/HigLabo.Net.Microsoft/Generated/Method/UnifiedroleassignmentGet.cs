using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignment-get?view=graph-rest-1.0
/// </summary>
public partial class UnifiedroleAssignmentGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.RoleManagement_Directory_RoleAssignments_Id: return $"/roleManagement/directory/roleAssignments/{Id}";
                case ApiPath.RoleManagement_EntitlementManagement_RoleAssignments_Id: return $"/roleManagement/entitlementManagement/roleAssignments/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        RoleManagement_Directory_RoleAssignments_Id,
        RoleManagement_EntitlementManagement_RoleAssignments_Id,
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
public partial class UnifiedroleAssignmentGetResponse : RestApiResponse
{
    public string? AppScopeId { get; set; }
    public string? DirectoryScopeId { get; set; }
    public string? Id { get; set; }
    public string? RoleDefinitionId { get; set; }
    public string? PrincipalId { get; set; }
    public AppScope? AppScope { get; set; }
    public DirectoryObject? DirectoryScope { get; set; }
    public DirectoryObject? Principal { get; set; }
    public UnifiedRoleDefinition? RoleDefinition { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignment-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignment-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentGetResponse> UnifiedroleAssignmentGetAsync()
    {
        var p = new UnifiedroleAssignmentGetParameter();
        return await this.SendAsync<UnifiedroleAssignmentGetParameter, UnifiedroleAssignmentGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignment-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentGetResponse> UnifiedroleAssignmentGetAsync(CancellationToken cancellationToken)
    {
        var p = new UnifiedroleAssignmentGetParameter();
        return await this.SendAsync<UnifiedroleAssignmentGetParameter, UnifiedroleAssignmentGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignment-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentGetResponse> UnifiedroleAssignmentGetAsync(UnifiedroleAssignmentGetParameter parameter)
    {
        return await this.SendAsync<UnifiedroleAssignmentGetParameter, UnifiedroleAssignmentGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignment-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UnifiedroleAssignmentGetResponse> UnifiedroleAssignmentGetAsync(UnifiedroleAssignmentGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UnifiedroleAssignmentGetParameter, UnifiedroleAssignmentGetResponse>(parameter, cancellationToken);
    }
}
