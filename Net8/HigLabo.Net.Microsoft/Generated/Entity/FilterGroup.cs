using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-filtergroup?view=graph-rest-1.0
    /// </summary>
    public partial class FilterGroup
    {
        public FilterClause[]? Clauses { get; set; }
        public string? Name { get; set; }
    }
}
