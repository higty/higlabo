using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/educationteacher?view=graph-rest-1.0
    /// </summary>
    public partial class Teacher
    {
        public string? ExternalId { get; set; }
        public string? TeacherNumber { get; set; }
    }
}
