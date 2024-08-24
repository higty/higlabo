using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-hostportcomponent?view=graph-rest-1.0
    /// </summary>
    public partial class HostPortComponent
    {
        public DateTimeOffset? FirstSeenDateTime { get; set; }
        public bool? IsRecent { get; set; }
        public DateTimeOffset? LastSeenDateTime { get; set; }
        public HostComponent? Component { get; set; }
    }
}
