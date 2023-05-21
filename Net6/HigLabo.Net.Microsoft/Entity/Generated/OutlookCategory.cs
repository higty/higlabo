using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/outlookcategory?view=graph-rest-1.0
    /// </summary>
    public partial class OutlookCategory
    {
        public string? Color { get; set; }
        public string? DisplayName { get; set; }
    }
}
