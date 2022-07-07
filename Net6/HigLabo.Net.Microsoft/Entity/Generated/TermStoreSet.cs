using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/termstore-set?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreSet
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public TermStoreLocalizedName[]? LocalizedNames { get; set; }
        public KeyValue[]? Properties { get; set; }
    }
}
