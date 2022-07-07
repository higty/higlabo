using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/calltranscriptioninfo?view=graph-rest-1.0
    /// </summary>
    public partial class CallTranscriptionInfo
    {
        public string? State { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }
}
