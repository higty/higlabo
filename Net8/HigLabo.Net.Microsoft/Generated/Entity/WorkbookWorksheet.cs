using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookworksheet?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookWorksheet
    {
        public enum WorkbookWorksheetstring
        {
            Visible,
            Hidden,
            VeryHidden,
        }

        public string? Id { get; set; }
        public string? Name { get; set; }
        public int? Position { get; set; }
        public WorkbookWorksheetstring Visibility { get; set; }
        public WorkbookChart[]? Charts { get; set; }
        public WorkbookNamedItem[]? Names { get; set; }
        public PivotTable[]? PivotTables { get; set; }
        public WorkbookWorksheetProtection? Protection { get; set; }
        public WorkbookTable[]? Tables { get; set; }
    }
}
