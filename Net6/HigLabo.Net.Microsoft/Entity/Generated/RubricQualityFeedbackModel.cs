using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/rubricqualityfeedbackmodel?view=graph-rest-1.0
    /// </summary>
    public partial class RubricQualityFeedbackModel
    {
        public ItemBody? Feedback { get; set; }
        public string QualityId { get; set; }
    }
}
