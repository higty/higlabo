using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/incomingcontext?view=graph-rest-1.0
    /// </summary>
    public partial class IncomingContext
    {
        public string SourceParticipantId { get; set; }
        public string ObservedParticipantId { get; set; }
        public IdentitySet? OnBehalfOf { get; set; }
        public IdentitySet? Transferor { get; set; }
    }
}
