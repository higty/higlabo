using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/lookupcolumn?view=graph-rest-1.0
    /// </summary>
    public partial class LookupColumn
    {
        public Boolean? AllowMultipleValues { get; set; }
        public Boolean? AllowUnlimitedLength { get; set; }
        public String? ColumnName { get; set; }
        public String? ListId { get; set; }
        public String? PrimaryLookupColumnId { get; set; }
    }
}
