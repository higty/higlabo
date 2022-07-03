using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/audio?view=graph-rest-1.0
    /// </summary>
    public partial class Audio
    {
        public String? Album { get; set; }
        public String? AlbumArtist { get; set; }
        public String? Artist { get; set; }
        public Int64? Bitrate { get; set; }
        public String? Composers { get; set; }
        public String? Copyright { get; set; }
        public Int16? Disc { get; set; }
        public Int16? DiscCount { get; set; }
        public Int64? Duration { get; set; }
        public String? Genre { get; set; }
        public Boolean? HasDrm { get; set; }
        public Boolean? IsVariableBitrate { get; set; }
        public String? Title { get; set; }
        public Int32? Track { get; set; }
        public Int32? TrackCount { get; set; }
        public Int32? Year { get; set; }
    }
}
