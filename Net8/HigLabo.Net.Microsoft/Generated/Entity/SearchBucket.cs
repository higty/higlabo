using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/searchbucket?view=graph-rest-1.0
    /// </summary>
    public partial class SearchBucket
    {
        public string? AggregationFilterToken { get; set; }
        public Int32? Count { get; set; }
        public string? Key { get; set; }
    }
}
