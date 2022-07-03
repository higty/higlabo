using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/educationassignmentdefaults?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentDefaults
    {
        public string Id { get; set; }
        public EducationAssignmentDefaultsEducationAddedStudentAction AddedStudentAction { get; set; }
        public EducationAssignmentDefaultsEducationAddToCalendarOptions AddToCalendarAction { get; set; }
        public TimeOnly DueTime { get; set; }
        public string NotificationChannelUrl { get; set; }
    }
}
