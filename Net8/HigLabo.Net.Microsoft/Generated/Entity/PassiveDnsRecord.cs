using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-passivednsrecord?view=graph-rest-1.0
    /// </summary>
    public partial class PassiveDnsRecord
    {
        public DateTimeOffset? CollectedDateTime { get; set; }
        public DateTimeOffset? FirstSeenDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastSeenDateTime { get; set; }
        public string? RecordType { get; set; }
        public Artifact? Artifact { get; set; }
        public Host? ParentHost { get; set; }
    }
}
