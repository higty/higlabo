using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/printjob?view=graph-rest-1.0
/// </summary>
public partial class PrintJob
{
    public PrintJobConfiguration? Configuration { get; set; }
    public UserIdentity? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public Boolean? IsFetchable { get; set; }
    public String? RedirectedFrom { get; set; }
    public String? RedirectedTo { get; set; }
    public PrintJobStatus? Status { get; set; }
    public PrintDocument[]? Documents { get; set; }
    public PrintTask[]? Tasks { get; set; }
}
