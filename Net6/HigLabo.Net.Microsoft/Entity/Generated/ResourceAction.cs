using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-rbac-resourceaction?view=graph-rest-1.0
    /// </summary>
    public partial class ResourceAction
    {
        public String[]? AllowedResourceActions { get; set; }
        public String[]? NotAllowedResourceActions { get; set; }
    }
}
