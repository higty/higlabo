using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-hostpair?view=graph-rest-1.0
    /// </summary>
    public partial class HostPair
    {
        public DateTimeOffset? FirstSeenDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastSeenDateTime { get; set; }
        public string? LinkKind { get; set; }
        public Host? ChildHost { get; set; }
        public Host? ParentHost { get; set; }
    }
}
