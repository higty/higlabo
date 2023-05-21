using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/chartaxes?view=graph-rest-1.0
    /// </summary>
    public partial class ChartAxes
    {
        public ChartAxis? CategoryAxis { get; set; }
        public ChartAxis? SeriesAxis { get; set; }
        public ChartAxis? ValueAxis { get; set; }
    }
}
