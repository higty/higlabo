using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/chartgridlines?view=graph-rest-1.0
    /// </summary>
    public partial class ChartGridlines
    {
        public bool? Visible { get; set; }
        public ChartGridlinesFormat? Format { get; set; }
    }
}
