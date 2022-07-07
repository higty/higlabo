using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleassignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignments_Id,
            RoleManagement_EntitlementManagement_RoleAssignments_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignments_Id: return $"/roleManagement/directory/roleAssignments/{Id}";
                    case ApiPath.RoleManagement_EntitlementManagement_RoleAssignments_Id: return $"/roleManagement/entitlementManagement/roleAssignments/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
    }
    public partial class UnifiedroleassignmentGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? RoleDefinitionId { get; set; }
        public string? PrincipalId { get; set; }
        public string? DirectoryScopeId { get; set; }
        public string? AppScopeId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentGetResponse> UnifiedroleassignmentGetAsync()
        {
            var p = new UnifiedroleassignmentGetParameter();
            return await this.SendAsync<UnifiedroleassignmentGetParameter, UnifiedroleassignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentGetResponse> UnifiedroleassignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleassignmentGetParameter();
            return await this.SendAsync<UnifiedroleassignmentGetParameter, UnifiedroleassignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentGetResponse> UnifiedroleassignmentGetAsync(UnifiedroleassignmentGetParameter parameter)
        {
            return await this.SendAsync<UnifiedroleassignmentGetParameter, UnifiedroleassignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentGetResponse> UnifiedroleassignmentGetAsync(UnifiedroleassignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleassignmentGetParameter, UnifiedroleassignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
