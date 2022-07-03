using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/range?view=graph-rest-1.0
    /// </summary>
    public partial class Range
    {
        public String? Address { get; set; }
        public String? AddressLocal { get; set; }
        public int CellCount { get; set; }
        public int ColumnCount { get; set; }
        public Boolean? ColumnHidden { get; set; }
        public int ColumnIndex { get; set; }
        public Json? Formulas { get; set; }
        public Json? FormulasLocal { get; set; }
        public Json? FormulasR1C1 { get; set; }
        public Boolean? Hidden { get; set; }
        public Json? NumberFormat { get; set; }
        public int RowCount { get; set; }
        public Boolean? RowHidden { get; set; }
        public int RowIndex { get; set; }
        public Json? Text { get; set; }
        public RangeJson ValueTypes { get; set; }
        public Json? Values { get; set; }
    }
}
