using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/toneinfo?view=graph-rest-1.0
    /// </summary>
    public partial class ToneInfo
    {
        public enum ToneInfoTone
        {
            Tone0,
            Tone1,
            Tone2,
            Tone3,
            Tone4,
            Tone5,
            Tone6,
            Tone7,
            Tone8,
            Tone9,
            Star,
            Pound,
            A,
            B,
            C,
            D,
            Flash,
        }

        public Int64? SequenceId { get; set; }
        public ToneInfoTone Tone { get; set; }
    }
}
