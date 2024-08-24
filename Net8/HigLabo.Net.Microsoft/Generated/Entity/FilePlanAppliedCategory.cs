using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-fileplanappliedcategory?view=graph-rest-1.0
    /// </summary>
    public partial class FilePlanAppliedCategory
    {
        public string? DisplayName { get; set; }
        public FilePlanSubCategory? Subcategory { get; set; }
    }
}
