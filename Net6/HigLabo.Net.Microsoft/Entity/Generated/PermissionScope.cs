using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/permissionscope?view=graph-rest-1.0
    /// </summary>
    public partial class PermissionScope
    {
        public string AdminConsentDescription { get; set; }
        public string AdminConsentDisplayName { get; set; }
        public Guid? Id { get; set; }
        public bool IsEnabled { get; set; }
        public string Type { get; set; }
        public string UserConsentDescription { get; set; }
        public string UserConsentDisplayName { get; set; }
        public string Value { get; set; }
    }
}
