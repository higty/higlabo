using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/printershare?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterShare
    {
        public bool? AllowAllUsers { get; set; }
        public PrinterCapabilities? Capabilities { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public PrinterDefaults? Defaults { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsAcceptingJobs { get; set; }
        public PrinterLocation? Location { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public PrinterStatus? Status { get; set; }
        public Printer? Printer { get; set; }
        public User[]? AllowedUsers { get; set; }
        public Group? AllowedGroups { get; set; }
        public PrintJob[]? Jobs { get; set; }
    }
}
