using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/educationassignmentresource?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentResource
    {
        public bool? DistributeForStudentWork { get; set; }
        public string? Id { get; set; }
        public EducationResource? Resource { get; set; }
    }
}
