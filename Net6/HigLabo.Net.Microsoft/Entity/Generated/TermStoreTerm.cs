using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/termstore-term?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreTerm
    {
        public DateTimeOffset CreatedDateTime { get; set; }
        public TermStoreLocalizedDescription[] Descriptions { get; set; }
        public string Id { get; set; }
        public TermStoreLocalizedLabel[] Labels { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public KeyValue[] Properties { get; set; }
    }
}
