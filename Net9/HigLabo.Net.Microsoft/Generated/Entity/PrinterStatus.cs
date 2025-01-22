using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/printerstatus?view=graph-rest-1.0
/// </summary>
public partial class PrinterStatus
{
    public string? Description { get; set; }
    public PrinterProcessingStateDetail[]? Details { get; set; }
    public PrinterProcessingState? State { get; set; }
}
