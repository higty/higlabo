using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewreviewerscope?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewReviewerScope
    {
        public string? Query { get; set; }
        public string? QueryRoot { get; set; }
        public string? QueryType { get; set; }
    }
}
