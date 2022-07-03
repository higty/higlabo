using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/printjobstatus?view=graph-rest-1.0
    /// </summary>
    public partial class PrintJobStatus
    {
        public PrintJobProcessingState? State { get; set; }
        public PrintJobProcessingDetail[] Details { get; set; }
        public string Description { get; set; }
        public bool IsAcquiredByPrinter { get; set; }
    }
}
