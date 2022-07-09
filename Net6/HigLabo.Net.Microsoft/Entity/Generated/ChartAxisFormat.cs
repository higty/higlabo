using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/chartaxisformat?view=graph-rest-1.0
    /// </summary>
    public partial class ChartAxisFormat
    {
        public ChartFont? Font { get; set; }
        public ChartLineFormat? Line { get; set; }
    }
}
