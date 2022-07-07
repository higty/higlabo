using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/rangeformat?view=graph-rest-1.0
    /// </summary>
    public partial class RangeFormat
    {
        public enum RangeFormatstring
        {
            General,
            Left,
            Center,
            Right,
            Fill,
            Justify,
            CenterAcrossSelection,
            Distributed,
        }

        public Double? ColumnWidth { get; set; }
        public RangeFormatstring HorizontalAlignment { get; set; }
        public Double? RowHeight { get; set; }
        public RangeFormatstring VerticalAlignment { get; set; }
        public bool? WrapText { get; set; }
    }
}
