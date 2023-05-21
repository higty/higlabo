using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/printjobconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class PrintJobConfiguration
    {
        public bool? Collate { get; set; }
        public PrintColorMode? ColorMode { get; set; }
        public Int32? Copies { get; set; }
        public Int32? Dpi { get; set; }
        public PrintDuplexMode? DuplexMode { get; set; }
        public PrinterFeedOrientation? FeedOrientation { get; set; }
        public PrintFinishing[]? Finishings { get; set; }
        public string? InputBin { get; set; }
        public PrintMargin? Margin { get; set; }
        public string? MediaSize { get; set; }
        public string? MediaType { get; set; }
        public PrintMultipageLayout? MultipageLayout { get; set; }
        public PrintOrientation? Orientation { get; set; }
        public string? OutputBin { get; set; }
        public IntegerRange[]? PageRanges { get; set; }
        public Int32? PagesPerSheet { get; set; }
        public PrintQuality? Quality { get; set; }
        public PrintScaling? Scaling { get; set; }
    }
}
