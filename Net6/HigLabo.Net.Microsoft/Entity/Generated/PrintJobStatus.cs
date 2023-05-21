using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/printjobstatus?view=graph-rest-1.0
    /// </summary>
    public partial class PrintJobStatus
    {
        public string? Description { get; set; }
        public PrintJobProcessingDetail[]? Details { get; set; }
        public bool? IsAcquiredByPrinter { get; set; }
        public PrintJobProcessingState? State { get; set; }
    }
}
