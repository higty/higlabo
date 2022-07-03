using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/printconnector?view=graph-rest-1.0
    /// </summary>
    public partial class PrintConnector
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string FullyQualifiedDomainName { get; set; }
        public string OperatingSystem { get; set; }
        public string AppVersion { get; set; }
        public PrinterLocation? Location { get; set; }
        public DateTimeOffset RegisteredDateTime { get; set; }
        public UserIdentity? RegisteredBy { get; set; }
    }
}
