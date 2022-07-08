using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/printjob?view=graph-rest-1.0
    /// </summary>
    public partial class PrintJob
    {
        public string? Id { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public PrintJobStatus? Status { get; set; }
        public PrintJobConfiguration? Configuration { get; set; }
        public Boolean? IsFetchable { get; set; }
        public String? RedirectedFrom { get; set; }
        public String? RedirectedTo { get; set; }
        public UserIdentity? CreatedBy { get; set; }
        public PrintDocument[]? Documents { get; set; }
        public PrintTask[]? Tasks { get; set; }
    }
}
