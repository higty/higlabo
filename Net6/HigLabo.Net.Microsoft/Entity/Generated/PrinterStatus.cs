using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/printerstatus?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterStatus
    {
        public PrinterProcessingState? State { get; set; }
        public PrinterProcessingStateDetail[]? Details { get; set; }
        public string? Description { get; set; }
    }
}
