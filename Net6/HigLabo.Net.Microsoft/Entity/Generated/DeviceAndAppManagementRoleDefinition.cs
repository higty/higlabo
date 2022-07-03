using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-rbac-deviceandappmanagementroledefinition?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceAndAppManagementRoleDefinition
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public RolePermission[] RolePermissions { get; set; }
        public bool IsBuiltIn { get; set; }
    }
}
