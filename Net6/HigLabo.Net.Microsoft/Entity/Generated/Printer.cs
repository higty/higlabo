using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/printer?view=graph-rest-1.0
    /// </summary>
    public partial class Printer
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public DateTimeOffset? RegisteredDateTime { get; set; }
        public PrinterStatus? Status { get; set; }
        public bool? IsShared { get; set; }
        public bool? HasPhysicalDevice { get; set; }
        public bool? IsAcceptingJobs { get; set; }
        public PrinterLocation? Location { get; set; }
        public PrinterDefaults? Defaults { get; set; }
        public PrinterCapabilities? Capabilities { get; set; }
        public DateTimeOffset? LastSeenDateTime { get; set; }
        public PrintJob[]? Jobs { get; set; }
        public PrinterShare[]? Shares { get; set; }
        public PrintConnector? Connectors { get; set; }
        public PrintTaskTrigger[]? TaskTriggers { get; set; }
    }
}
