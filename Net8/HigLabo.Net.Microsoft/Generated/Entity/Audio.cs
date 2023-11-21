using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/audio?view=graph-rest-1.0
    /// </summary>
    public partial class Audio
    {
        public string? Album { get; set; }
        public string? AlbumArtist { get; set; }
        public string? Artist { get; set; }
        public Int64? Bitrate { get; set; }
        public string? Composers { get; set; }
        public string? Copyright { get; set; }
        public Int16? Disc { get; set; }
        public Int16? DiscCount { get; set; }
        public Int64? Duration { get; set; }
        public string? Genre { get; set; }
        public bool? HasDrm { get; set; }
        public bool? IsVariableBitrate { get; set; }
        public string? Title { get; set; }
        public Int32? Track { get; set; }
        public Int32? TrackCount { get; set; }
        public Int32? Year { get; set; }
    }
}
