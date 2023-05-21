using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/searchquery?view=graph-rest-1.0
    /// </summary>
    public partial class SearchQuery
    {
        public string? QueryString { get; set; }
        public string? QueryTemplate { get; set; }
    }
}
