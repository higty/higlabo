using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/printoperationstatus?view=graph-rest-1.0
    /// </summary>
    public partial class PrintOperationStatus
    {
        public string? Description { get; set; }
        public PrintOperationProcessingState? State { get; set; }
    }
}
