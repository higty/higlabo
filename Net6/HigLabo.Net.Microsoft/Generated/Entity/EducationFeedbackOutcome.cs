using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/educationfeedbackoutcome?view=graph-rest-1.0
    /// </summary>
    public partial class EducationFeedbackOutcome
    {
        public EducationFeedback? Feedback { get; set; }
        public string? Id { get; set; }
        public EducationFeedback? PublishedFeedback { get; set; }
    }
}
