using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/searchentity?view=graph-rest-1.0
    /// </summary>
    public partial class SearchEntity
    {
        public Acronym[]? Acronyms { get; set; }
        public Bookmark[]? Bookmarks { get; set; }
        public Qna[]? Qnas { get; set; }
    }
}
