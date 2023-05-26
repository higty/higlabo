using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/chartseries?view=graph-rest-1.0
    /// </summary>
    public partial class ChartSeries
    {
        public string? Name { get; set; }
        public ChartSeriesFormat? Format { get; set; }
        public ChartPoint[]? Points { get; set; }
    }
}
