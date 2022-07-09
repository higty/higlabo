using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/outlookcategory?view=graph-rest-1.0
    /// </summary>
    public partial class OutlookCategory
    {
        public string? DisplayName { get; set; }
        public string? Color { get; set; }
    }
}
