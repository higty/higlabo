using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/archivedprintjob?view=graph-rest-1.0
    /// </summary>
    public partial class ArchivedPrintJob
    {
        public bool? AcquiredByPrinter { get; set; }
        public DateTimeOffset? AcquiredDateTime { get; set; }
        public DateTimeOffset? CompletionDateTime { get; set; }
        public Int32? CopiesPrinted { get; set; }
        public UserIdentity? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public string? PrinterId { get; set; }
        public PrintJobProcessingState? ProcessingState { get; set; }
    }
}
