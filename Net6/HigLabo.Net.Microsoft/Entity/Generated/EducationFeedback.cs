using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/educationfeedback?view=graph-rest-1.0
    /// </summary>
    public partial class EducationFeedback
    {
        public IdentitySet FeedbackBy { get; set; }
        public DateTimeOffset FeedbackDateTime { get; set; }
        public ItemBody Text { get; set; }
    }
}
