using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/educationstudent?view=graph-rest-1.0
    /// </summary>
    public partial class EducationStudent
    {
        public enum EducationStudentEducationGender
        {
            Female,
            Male,
            Other,
            UnknownFutureValue,
        }

        public DateOnly? BirthDate { get; set; }
        public string? ExternalId { get; set; }
        public EducationStudentEducationGender Gender { get; set; }
        public string? Grade { get; set; }
        public string? GraduationYear { get; set; }
        public string? StudentNumber { get; set; }
    }
}
