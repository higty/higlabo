using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/educationschool?view=graph-rest-1.0
    /// </summary>
    public partial class EducationSchool
    {
        public PhysicalAddress? Address { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string ExternalId { get; set; }
        public string ExternalPrincipalId { get; set; }
        public EducationSchoolEducationExternalSource ExternalSource { get; set; }
        public string ExternalSourceDetail { get; set; }
        public string HighestGrade { get; set; }
        public string Id { get; set; }
        public string LowestGrade { get; set; }
        public string Phone { get; set; }
        public string PrincipalEmail { get; set; }
        public string PrincipalName { get; set; }
        public string SchoolNumber { get; set; }
    }
}
