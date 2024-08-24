using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbooknameditem?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookNamedItem
    {
        public string? Comment { get; set; }
        public string? Name { get; set; }
        public string? Scope { get; set; }
        public string? Type { get; set; }
        public string? Value { get; set; }
        public bool? Visible { get; set; }
        public WorkbookWorksheet? Worksheet { get; set; }
    }
}
