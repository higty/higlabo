using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/permissiongrantconditionset?view=graph-rest-1.0
    /// </summary>
    public partial class PermissionGrantConditionSet
    {
        public enum PermissionGrantConditionSetPermissionType
        {
            Application,
            Delegated,
            DelegatedUserConsentable,
        }

        public string? Id { get; set; }
        public string? PermissionClassification { get; set; }
        public PermissionGrantConditionSetPermissionType PermissionType { get; set; }
        public string? ResourceApplication { get; set; }
        public String[]? Permissions { get; set; }
        public String[]? ClientApplicationIds { get; set; }
        public String[]? ClientApplicationTenantIds { get; set; }
        public String[]? ClientApplicationPublisherIds { get; set; }
        public bool? ClientApplicationsFromVerifiedPublisherOnly { get; set; }
    }
}
