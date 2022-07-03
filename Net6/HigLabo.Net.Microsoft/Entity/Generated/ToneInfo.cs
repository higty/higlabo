using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/toneinfo?view=graph-rest-1.0
    /// </summary>
    public partial class ToneInfo
    {
        public Int64? SequenceId { get; set; }
        public ToneInfoTone Tone { get; set; }
    }
}
