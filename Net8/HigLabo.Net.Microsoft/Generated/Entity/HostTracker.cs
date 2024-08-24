using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-hosttracker?view=graph-rest-1.0
    /// </summary>
    public partial class HostTracker
    {
        public DateTimeOffset? FirstSeenDateTime { get; set; }
        public string? Id { get; set; }
        public string? Kind { get; set; }
        public DateTimeOffset? LastSeenDateTime { get; set; }
        public string? Value { get; set; }
        public Host? Host { get; set; }
    }
}
