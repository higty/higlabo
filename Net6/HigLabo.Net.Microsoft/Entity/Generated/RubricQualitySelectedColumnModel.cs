using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/rubricqualityselectedcolumnmodel?view=graph-rest-1.0
    /// </summary>
    public partial class RubricQualitySelectedColumnModel
    {
        public string ColumnId { get; set; }
        public string QualityId { get; set; }
    }
}
