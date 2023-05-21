using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/educationassignmentpointsgrade?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentPointsGrade
    {
        public IdentitySet? GradedBy { get; set; }
        public DateTimeOffset? GradedDateTime { get; set; }
        public Single? Points { get; set; }
    }
}
