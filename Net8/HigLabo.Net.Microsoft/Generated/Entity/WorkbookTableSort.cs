using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbooktablesort?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookTableSort
    {
        public enum WorkbookTableSortstring
        {
            PinYin,
            StrokeCount,
        }

        public SortField[]? Fields { get; set; }
        public bool? MatchCase { get; set; }
        public WorkbookTableSortstring Method { get; set; }
    }
}
