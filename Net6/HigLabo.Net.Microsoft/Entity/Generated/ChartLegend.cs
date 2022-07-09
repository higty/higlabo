using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/chartlegend?view=graph-rest-1.0
    /// </summary>
    public partial class ChartLegend
    {
        public enum ChartLegendstring
        {
            Top,
            Bottom,
            Left,
            Right,
            Corner,
            Custom,
        }

        public bool? Overlay { get; set; }
        public ChartLegendstring Position { get; set; }
        public bool? Visible { get; set; }
        public ChartLegendFormat? Format { get; set; }
    }
}
