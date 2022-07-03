using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/contenttype?view=graph-rest-1.0
    /// </summary>
    public partial class ContentType
    {
        public String[] AssociatedHubsUrls { get; set; }
        public String? Description { get; set; }
        public DocumentSet? DocumentSet { get; set; }
        public DocumentSetContent? DocumentTemplate { get; set; }
        public String? Group { get; set; }
        public bool Hidden { get; set; }
        public String? Id { get; set; }
        public ItemReference? InheritedFrom { get; set; }
        public bool IsBuiltIn { get; set; }
        public String? Name { get; set; }
        public ContentTypeOrder? Order { get; set; }
        public String? ParentId { get; set; }
        public bool PropagateChanges { get; set; }
        public bool ReadOnly { get; set; }
        public bool Sealed { get; set; }
    }
}
