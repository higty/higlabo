using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/print?view=graph-rest-1.0
    /// </summary>
    public partial class Print
    {
        public PrintSettings? Settings { get; set; }
        public PrintConnector[]? Connectors { get; set; }
        public PrintOperation[]? Operations { get; set; }
        public Printer[]? Printers { get; set; }
        public PrintService[]? Services { get; set; }
        public PrinterShare[]? Shares { get; set; }
        public PrintTaskDefinition[]? TaskDefinitions { get; set; }
    }
}
