using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/chartseriesformat?view=graph-rest-1.0
    /// </summary>
    public partial class ChartSeriesFormat
    {
        public ChartFill? Fill { get; set; }
        public ChartLineFormat? Line { get; set; }
    }
}
