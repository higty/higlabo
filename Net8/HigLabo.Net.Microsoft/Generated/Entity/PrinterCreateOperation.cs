using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/printercreateoperation?view=graph-rest-1.0
/// </summary>
public partial class PrinterCreateOperation
{
    public string? Certificate { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public PrintOperationStatus? Status { get; set; }
    public Printer? Printer { get; set; }
}
