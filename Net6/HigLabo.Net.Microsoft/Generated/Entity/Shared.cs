using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/shared?view=graph-rest-1.0
    /// </summary>
    public partial class Shared
    {
        public IdentitySet? Owner { get; set; }
        public string? Scope { get; set; }
        public IdentitySet? SharedBy { get; set; }
        public DateTimeOffset? SharedDateTime { get; set; }
    }
}
