using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/rubriclevel?view=graph-rest-1.0
    /// </summary>
    public partial class RubricLevel
    {
        public ItemBody? Description { get; set; }
        public string? DisplayName { get; set; }
        public EducationAssignmentGradeType? Grading { get; set; }
        public string? LevelId { get; set; }
    }
}
