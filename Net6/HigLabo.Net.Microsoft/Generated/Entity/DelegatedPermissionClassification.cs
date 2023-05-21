using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/delegatedpermissionclassification?view=graph-rest-1.0
    /// </summary>
    public partial class DelegatedPermissionClassification
    {
        public enum DelegatedPermissionClassificationPermissionClassificationType
        {
            Low,
        }

        public DelegatedPermissionClassificationPermissionClassificationType Classification { get; set; }
        public string? Id { get; set; }
        public string? PermissionId { get; set; }
        public string? PermissionName { get; set; }
    }
}
