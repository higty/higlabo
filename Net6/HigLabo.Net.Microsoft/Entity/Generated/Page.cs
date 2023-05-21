using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/page?view=graph-rest-1.0
    /// </summary>
    public partial class Page
    {
        public Stream? Content { get; set; }
        public string? ContentUrl { get; set; }
        public string? CreatedByAppId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public Int32? Level { get; set; }
        public PageLinks? Links { get; set; }
        public Int32? Order { get; set; }
        public string? Self { get; set; }
        public string? Title { get; set; }
        public Notebook? ParentNotebook { get; set; }
        public Section? ParentSection { get; set; }
    }
}
