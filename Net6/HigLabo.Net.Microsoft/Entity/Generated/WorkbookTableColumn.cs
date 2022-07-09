using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/workbooktablecolumn?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookTableColumn
    {
        public string? Id { get; set; }
        public int? Index { get; set; }
        public string? Name { get; set; }
        public Json? Values { get; set; }
        public Filter? Filter { get; set; }
    }
}
