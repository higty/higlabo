using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/accessreviewqueryscope?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewQueryScope
    {
        public string? Query { get; set; }
        public string? QueryRoot { get; set; }
        public string? QueryType { get; set; }
    }
}
