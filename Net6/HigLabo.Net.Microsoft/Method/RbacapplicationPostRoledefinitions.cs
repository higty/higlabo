using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RbacapplicationPostRoledefinitionsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            RoleManagement_Directory_RoleDefinitions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleDefinitions: return $"/roleManagement/directory/roleDefinitions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public bool? IsEnabled { get; set; }
        public UnifiedRolePermission[]? RolePermissions { get; set; }
    }
    public partial class RbacapplicationPostRoledefinitionsResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-post-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoledefinitionsResponse> RbacapplicationPostRoledefinitionsAsync()
        {
            var p = new RbacapplicationPostRoledefinitionsParameter();
            return await this.SendAsync<RbacapplicationPostRoledefinitionsParameter, RbacapplicationPostRoledefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-post-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoledefinitionsResponse> RbacapplicationPostRoledefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationPostRoledefinitionsParameter();
            return await this.SendAsync<RbacapplicationPostRoledefinitionsParameter, RbacapplicationPostRoledefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-post-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoledefinitionsResponse> RbacapplicationPostRoledefinitionsAsync(RbacapplicationPostRoledefinitionsParameter parameter)
        {
            return await this.SendAsync<RbacapplicationPostRoledefinitionsParameter, RbacapplicationPostRoledefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-post-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoledefinitionsResponse> RbacapplicationPostRoledefinitionsAsync(RbacapplicationPostRoledefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationPostRoledefinitionsParameter, RbacapplicationPostRoledefinitionsResponse>(parameter, cancellationToken);
        }
    }
}
