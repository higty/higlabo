using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/chart?view=graph-rest-1.0
    /// </summary>
    public partial class Chart
    {
        public Double? Height { get; set; }
        public string? Id { get; set; }
        public Double? Left { get; set; }
        public string? Name { get; set; }
        public Double? Top { get; set; }
        public Double? Width { get; set; }
        public ChartAxes? Axes { get; set; }
        public ChartDataLabels? DataLabels { get; set; }
        public ChartAreaFormat? Format { get; set; }
        public ChartLegend? Legend { get; set; }
        public ChartSeries[]? Series { get; set; }
        public ChartTitle? Title { get; set; }
        public Worksheet? Worksheet { get; set; }
    }
}
