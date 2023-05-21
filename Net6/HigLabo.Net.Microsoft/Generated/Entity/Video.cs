using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/video?view=graph-rest-1.0
    /// </summary>
    public partial class Video
    {
        public Int32? AudioBitsPerSample { get; set; }
        public Int32? AudioChannels { get; set; }
        public string? AudioFormat { get; set; }
        public Int32? AudioSamplesPerSecond { get; set; }
        public Int32? Bitrate { get; set; }
        public Int64? Duration { get; set; }
        public string? FourCC { get; set; }
        public Double? FrameRate { get; set; }
        public Int32? Height { get; set; }
        public Int32? Width { get; set; }
    }
}
