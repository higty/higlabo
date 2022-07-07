using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/list?view=graph-rest-1.0
    /// </summary>
    public partial class SiteList
    {
        public string? DisplayName { get; set; }
        public ListInfo? List { get; set; }
        public System? System { get; set; }
    }
}
