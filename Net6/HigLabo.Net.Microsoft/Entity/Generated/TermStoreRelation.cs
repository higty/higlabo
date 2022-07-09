using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/termstore-relation?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreRelation
    {
        public enum TermStoreRelationTermStoreRelationType
        {
            Pin,
            Reuse,
        }

        public string? Id { get; set; }
        public TermStoreRelationTermStoreRelationType Relationship { get; set; }
        public TermStoreTerm? FromTerm { get; set; }
        public TermStoreSet? Set { get; set; }
        public TermStoreTerm? ToTerm { get; set; }
    }
}
