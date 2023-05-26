using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/printtaskstatus?view=graph-rest-1.0
    /// </summary>
    public partial class PrintTaskStatus
    {
        public string? Description { get; set; }
        public PrintTaskProcessingState? State { get; set; }
    }
}
