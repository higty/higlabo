using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/printerdefaults?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterDefaults
    {
        public Int32? CopiesPerJob { get; set; }
        public string? ContentType { get; set; }
        public PrintFinishing[]? Finishings { get; set; }
        public string? MediaColor { get; set; }
        public string? MediaType { get; set; }
        public string? MediaSize { get; set; }
        public Int32? PagesPerSheet { get; set; }
        public PrintOrientation? Orientation { get; set; }
        public string? OutputBin { get; set; }
        public bool? FitPdfToPage { get; set; }
        public PrintMultipageLayout? MultipageLayout { get; set; }
        public PrintColorMode? ColorMode { get; set; }
        public PrintQuality? Quality { get; set; }
        public PrintDuplexMode? DuplexMode { get; set; }
        public Int32? Dpi { get; set; }
        public PrintScaling? Scaling { get; set; }
    }
}
