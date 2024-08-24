using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/educationmodule?view=graph-rest-1.0
    /// </summary>
    public partial class EducationModule
    {
        public enum EducationModulestring
        {
            Draft,
            Published,
        }

        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsPinned { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? ResourcesFolderUrl { get; set; }
        public EducationModulestring Status { get; set; }
        public EducationModuleResource[]? Resources { get; set; }
    }
}
