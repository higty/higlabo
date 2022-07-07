using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-rbac-rolepermission?view=graph-rest-1.0
    /// </summary>
    public partial class RolePermission
    {
        public ResourceAction[]? ResourceActions { get; set; }
    }
}
