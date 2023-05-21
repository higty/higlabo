using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/unifiedrolepermission?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedRolePermission
    {
        public String[]? AllowedResourceActions { get; set; }
        public string? Condition { get; set; }
        public String[]? ExcludedResourceActions { get; set; }
    }
}
