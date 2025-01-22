using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/printusagebyprinter?view=graph-rest-1.0
/// </summary>
public partial class PrintUsageByPrinter
{
    public Int64? CompletedBlackAndWhiteJobCount { get; set; }
    public Int64? CompletedColorJobCount { get; set; }
    public string? Id { get; set; }
    public Int64? IncompleteJobCount { get; set; }
    public string? PrinterID { get; set; }
    public DateOnly? UsageDate { get; set; }
}
