using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roledefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class RbacapplicationPostRoledefinitionsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleDefinitions: return $"/roleManagement/directory/roleDefinitions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            RoleManagement_Directory_RoleDefinitions,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public bool? IsEnabled { get; set; }
        public UnifiedRolePermission[]? RolePermissions { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public bool? IsBuiltIn { get; set; }
        public String[]? ResourceScopes { get; set; }
        public string? TemplateId { get; set; }
        public string? Version { get; set; }
        public UnifiedRoleDefinition[]? InheritsPermissionsFrom { get; set; }
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
        public UnifiedRoleDefinition[]? InheritsPermissionsFrom { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roledefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoledefinitionsResponse> RbacapplicationPostRoledefinitionsAsync()
        {
            var p = new RbacapplicationPostRoledefinitionsParameter();
            return await this.SendAsync<RbacapplicationPostRoledefinitionsParameter, RbacapplicationPostRoledefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoledefinitionsResponse> RbacapplicationPostRoledefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationPostRoledefinitionsParameter();
            return await this.SendAsync<RbacapplicationPostRoledefinitionsParameter, RbacapplicationPostRoledefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoledefinitionsResponse> RbacapplicationPostRoledefinitionsAsync(RbacapplicationPostRoledefinitionsParameter parameter)
        {
            return await this.SendAsync<RbacapplicationPostRoledefinitionsParameter, RbacapplicationPostRoledefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoledefinitionsResponse> RbacapplicationPostRoledefinitionsAsync(RbacapplicationPostRoledefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationPostRoledefinitionsParameter, RbacapplicationPostRoledefinitionsResponse>(parameter, cancellationToken);
        }
    }
}
