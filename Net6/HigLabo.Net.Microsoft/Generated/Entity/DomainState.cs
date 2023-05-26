using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/domainstate?view=graph-rest-1.0
    /// </summary>
    public partial class DomainState
    {
        public DateTimeOffset? LastActionDateTime { get; set; }
        public string? Operation { get; set; }
        public string? Status { get; set; }
    }
}
