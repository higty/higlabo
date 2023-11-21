using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/unifiedrolemanagementpolicyruletarget?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedRoleManagementPolicyRuleTarget
    {
        public string? Caller { get; set; }
        public String[]? EnforcedSettings { get; set; }
        public String[]? InheritableSettings { get; set; }
        public string? Level { get; set; }
        public String[]? Operations { get; set; }
        public DirectoryObject[]? TargetObjects { get; set; }
    }
}
