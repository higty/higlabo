using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/tablesort?view=graph-rest-1.0
    /// </summary>
    public partial class TableSort
    {
        public enum TableSortstring
        {
            PinYin,
            StrokeCount,
        }

        public SortField[]? Fields { get; set; }
        public bool? MatchCase { get; set; }
        public TableSortstring Method { get; set; }
    }
}
