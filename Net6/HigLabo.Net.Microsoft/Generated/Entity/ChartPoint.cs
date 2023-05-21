using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/chartpoint?view=graph-rest-1.0
    /// </summary>
    public partial class ChartPoint
    {
        public string? Id { get; set; }
        public Json? Value { get; set; }
        public ChartPointFormat? Format { get; set; }
    }
}
