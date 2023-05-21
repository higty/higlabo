using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/termstore-term?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreTerm
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public TermStoreLocalizeddescription[]? Descriptions { get; set; }
        public string? Id { get; set; }
        public TermStoreLocalizedlabel[]? Labels { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public KeyValue[]? Properties { get; set; }
        public TermStoreTerm[]? Children { get; set; }
        public TermStoreRelation[]? Relations { get; set; }
        public TermStoreSet? Set { get; set; }
    }
}
