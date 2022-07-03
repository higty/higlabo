using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/externalconnectors-externalitem?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalItem
    {
        public Acl[] Acl { get; set; }
        public ExternalItemContent Content { get; set; }
        public string Id { get; set; }
        public string Properties { get; set; }
    }
}
