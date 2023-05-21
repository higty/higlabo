using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/pendingoperations?view=graph-rest-1.0
    /// </summary>
    public partial class PendingOperations
    {
        public PendingContentUpdate? PendingContentUpdate { get; set; }
    }
}
