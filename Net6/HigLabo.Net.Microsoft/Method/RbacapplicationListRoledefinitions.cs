using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RbacapplicationListRoledefinitionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleDefinitions,
            RoleManagement_EntitlementManagement_RoleDefinitions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleDefinitions: return $"/roleManagement/directory/roleDefinitions";
                    case ApiPath.RoleManagement_EntitlementManagement_RoleDefinitions: return $"/roleManagement/entitlementManagement/roleDefinitions";
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
    }
    public partial class RbacapplicationListRoledefinitionsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/unifiedroledefinition?view=graph-rest-1.0
        /// </summary>
        public partial class UnifiedRoleDefinition
        {
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public bool? IsBuiltIn { get; set; }
            public bool? IsEnabled { get; set; }
            public String[]? ResourceScopes { get; set; }
            public UnifiedRolePermission[]? RolePermissions { get; set; }
            public string? TemplateId { get; set; }
            public string? Version { get; set; }
        }

        public UnifiedRoleDefinition[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoledefinitionsResponse> RbacapplicationListRoledefinitionsAsync()
        {
            var p = new RbacapplicationListRoledefinitionsParameter();
            return await this.SendAsync<RbacapplicationListRoledefinitionsParameter, RbacapplicationListRoledefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoledefinitionsResponse> RbacapplicationListRoledefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationListRoledefinitionsParameter();
            return await this.SendAsync<RbacapplicationListRoledefinitionsParameter, RbacapplicationListRoledefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoledefinitionsResponse> RbacapplicationListRoledefinitionsAsync(RbacapplicationListRoledefinitionsParameter parameter)
        {
            return await this.SendAsync<RbacapplicationListRoledefinitionsParameter, RbacapplicationListRoledefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoledefinitionsResponse> RbacapplicationListRoledefinitionsAsync(RbacapplicationListRoledefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationListRoledefinitionsParameter, RbacapplicationListRoledefinitionsResponse>(parameter, cancellationToken);
        }
    }
}
