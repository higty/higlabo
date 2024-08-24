using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-filterclause?view=graph-rest-1.0
    /// </summary>
    public partial class FilterClause
    {
        public string? OperatorName { get; set; }
        public string? SourceOperandName { get; set; }
        public FilterOperand? TargetOperand { get; set; }
    }
}
