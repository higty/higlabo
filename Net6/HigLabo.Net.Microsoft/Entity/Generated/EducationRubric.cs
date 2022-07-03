using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/educationrubric?view=graph-rest-1.0
    /// </summary>
    public partial class EducationRubric
    {
        public string Id { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public ItemBody? Description { get; set; }
        public string DisplayName { get; set; }
        public EducationAssignmentGradeType? Grading { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public RubricLevel[] Levels { get; set; }
        public RubricQuality[] Qualities { get; set; }
    }
}
