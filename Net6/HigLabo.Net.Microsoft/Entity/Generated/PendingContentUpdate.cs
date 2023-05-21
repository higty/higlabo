using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/pendingcontentupdate?view=graph-rest-1.0
    /// </summary>
    public partial class PendingContentUpdate
    {
        public DateTimeOffset? QueuedDateTime { get; set; }
    }
}
