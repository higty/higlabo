using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroledefinition-update?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedroledefinitionUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleDefinitions_Id: return $"/roleManagement/directory/roleDefinitions/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            RoleManagement_Directory_RoleDefinitions_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsEnabled { get; set; }
        public String[]? ResourceScopes { get; set; }
        public UnifiedRolePermission[]? RolePermissions { get; set; }
        public string? TemplateId { get; set; }
        public string? Version { get; set; }
    }
    public partial class UnifiedroledefinitionUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroledefinition-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroledefinition-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroledefinitionUpdateResponse> UnifiedroledefinitionUpdateAsync()
        {
            var p = new UnifiedroledefinitionUpdateParameter();
            return await this.SendAsync<UnifiedroledefinitionUpdateParameter, UnifiedroledefinitionUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroledefinition-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroledefinitionUpdateResponse> UnifiedroledefinitionUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroledefinitionUpdateParameter();
            return await this.SendAsync<UnifiedroledefinitionUpdateParameter, UnifiedroledefinitionUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroledefinition-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroledefinitionUpdateResponse> UnifiedroledefinitionUpdateAsync(UnifiedroledefinitionUpdateParameter parameter)
        {
            return await this.SendAsync<UnifiedroledefinitionUpdateParameter, UnifiedroledefinitionUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroledefinition-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroledefinitionUpdateResponse> UnifiedroledefinitionUpdateAsync(UnifiedroledefinitionUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroledefinitionUpdateParameter, UnifiedroledefinitionUpdateResponse>(parameter, cancellationToken);
        }
    }
}
