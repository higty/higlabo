using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/printershare?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterShare
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public bool IsAcceptingJobs { get; set; }
        public PrinterDefaults? Defaults { get; set; }
        public PrinterCapabilities? Capabilities { get; set; }
        public PrinterLocation? Location { get; set; }
        public PrinterStatus? Status { get; set; }
        public bool AllowAllUsers { get; set; }
    }
}
