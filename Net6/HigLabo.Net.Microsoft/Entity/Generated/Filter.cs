using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/filter?view=graph-rest-1.0
    /// </summary>
    public partial class Filter
    {
        public FilterCriteria? Criteria { get; set; }
    }
}
