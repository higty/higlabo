using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/chartaxistitle?view=graph-rest-1.0
    /// </summary>
    public partial class ChartAxisTitle
    {
        public string? Text { get; set; }
        public bool? Visible { get; set; }
        public ChartAxisTitleFormat? Format { get; set; }
    }
}
