using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/workbook?view=graph-rest-1.0
    /// </summary>
    public partial class Workbook
    {
        public NamedItem[]? Names { get; set; }
        public Table[]? Tables { get; set; }
        public Worksheet[]? Worksheets { get; set; }
        public WorkbookOperation[]? Operations { get; set; }
    }
}
