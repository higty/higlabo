using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
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
}
