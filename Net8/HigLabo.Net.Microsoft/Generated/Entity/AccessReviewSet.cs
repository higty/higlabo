using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewset?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewSet
    {
        public AccessReviewScheduleDefinition[]? Definitions { get; set; }
        public AccessReviewHistoryDefinition[]? HistoryDefinitions { get; set; }
    }
}
