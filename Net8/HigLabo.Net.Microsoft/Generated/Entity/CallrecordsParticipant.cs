using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/callrecords-participant?view=graph-rest-1.0
    /// </summary>
    public partial class CallrecordsParticipant
    {
        public string? Id { get; set; }
        public CommunicationsIdentitySet? Identity { get; set; }
    }
}
