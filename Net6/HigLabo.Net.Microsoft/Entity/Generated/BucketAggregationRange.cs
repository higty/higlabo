using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/bucketaggregationrange?view=graph-rest-1.0
    /// </summary>
    public partial class BucketAggregationRange
    {
        public string From { get; set; }
        public string To { get; set; }
    }
}
