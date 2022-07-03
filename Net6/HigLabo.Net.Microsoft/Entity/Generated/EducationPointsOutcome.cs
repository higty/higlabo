using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/educationpointsoutcome?view=graph-rest-1.0
    /// </summary>
    public partial class EducationPointsOutcome
    {
        public string Id { get; set; }
        public EducationAssignmentPointsGrade? Points { get; set; }
        public EducationAssignmentPointsGrade? PublishedPoints { get; set; }
    }
}
