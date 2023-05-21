using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/lookupcolumn?view=graph-rest-1.0
    /// </summary>
    public partial class LookupColumn
    {
        public bool? AllowMultipleValues { get; set; }
        public bool? AllowUnlimitedLength { get; set; }
        public string? ColumnName { get; set; }
        public string? ListId { get; set; }
        public string? PrimaryLookupColumnId { get; set; }
    }
}
