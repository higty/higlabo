using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/restorepointsearchresponse?view=graph-rest-1.0
    /// </summary>
    public partial class ReStorePointSearchResponse
    {
        public String[]? NoResultProtectionUnitIds { get; set; }
        public string? SearchResponseId { get; set; }
        public ReStorePointSearchResult[]? SearchResults { get; set; }
    }
}
