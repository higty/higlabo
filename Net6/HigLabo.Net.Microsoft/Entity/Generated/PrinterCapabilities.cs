using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/printercapabilities?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterCapabilities
    {
        public String[]? ContentTypes { get; set; }
        public bool? IsColorPrintingSupported { get; set; }
        public PrinterFeedOrientation[]? FeedOrientations { get; set; }
        public bool? IsPageRangeSupported { get; set; }
        public Enum[]? Qualities { get; set; }
        public Int32[]? Dpis { get; set; }
        public Enum[]? DuplexModes { get; set; }
        public Int32? QueueBufferSizeInBytes { get; set; }
        public IntegerRange? CopiesPerJob { get; set; }
        public Enum[]? Finishings { get; set; }
        public String[]? MediaColors { get; set; }
        public String[]? MediaTypes { get; set; }
        public String[]? MediaSizes { get; set; }
        public Int32[]? PagesPerSheet { get; set; }
        public Enum[]? Orientations { get; set; }
        public String[]? InputBins { get; set; }
        public String[]? OutputBins { get; set; }
        public bool? SupportsFitPdfToPage { get; set; }
        public Enum[]? MultipageLayouts { get; set; }
        public Enum[]? ColorModes { get; set; }
        public Int32[]? TopMargins { get; set; }
        public Int32[]? BottomMargins { get; set; }
        public Int32[]? RightMargins { get; set; }
        public Int32[]? LeftMargins { get; set; }
        public bool? Collation { get; set; }
        public Enum[]? Scalings { get; set; }
    }
}
